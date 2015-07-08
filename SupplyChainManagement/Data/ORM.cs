using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SQLite;

using SupplyChainManagement.Models;
using SupplyChainManagement.Util;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Data
{
    public class ORM
    {
        private Dictionary<int, Item> _ItemCache = new Dictionary<int, Item>();

        public Dictionary<int, Workplace> _WorkplaceCache = new Dictionary<int, Workplace>();

        public Dictionary<int, ItemJob> _ItemJobCache = new Dictionary<int, ItemJob>();

        public ORM()
        {

            // Check whether directories and files do exist
            if (!Directory.Exists(Constants.MAIN_DIR))
            {
                Directory.CreateDirectory(Constants.MAIN_DIR);
            }

            if (!Directory.Exists(Constants.DATA_DIR))
            {
                Directory.CreateDirectory(Constants.DATA_DIR);
            }

            if (!File.Exists(Constants.DATABASE_FILE))
            {
                SQLiteConnection.CreateFile(Constants.DATABASE_FILE);

                using (var conn = new SQLiteConnection(Constants.CONNECTION_URI)) {
                    conn.Open();

                    CreateSchema();
                    WriteFixtures();
                }
            }

            _ReadFromDb();
        }

        public void Purge()
        {

            if (File.Exists(Constants.DATABASE_FILE))
            {
                File.Delete(Constants.DATABASE_FILE);
            }

            SQLiteConnection.CreateFile(Constants.DATABASE_FILE);

            using (var conn = new SQLiteConnection(Constants.CONNECTION_URI)) {
                conn.Open();

                CreateSchema();
                WriteFixtures();

                _ItemCache = new Dictionary<int, Item>();
                _ItemJobCache = new Dictionary<int, ItemJob>();
                _WorkplaceCache = new Dictionary<int, Workplace>();

                _ReadFromDb();
            }
        }

        private void _ReadFromDb() {
            using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            {
                conn.Open();

                _ReadItems(conn);
                _ReadChildsOfProducts(conn);
                _ReadWorkplaces(conn);
                _ReadItemJobs(conn);
                _ReadNextItemJobs(conn);
            }
        }

        private void _ReadItems(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "select * from " + Values.Item;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var type = (string)reader[Values.Type];

                        Item item;
                        if (type == Values.ProcuredItem)
                        {
                            item = new ProcuredItem();
                            item.Id = (int)reader[Values.Id];
                            item.Description = (string)reader[Values.Description];
                            item.Stock = (int)reader[Values.Stock];
                            item.Value = (double)reader[Values.Value];

                            (item as ProcuredItem).DiscountQuantity = (int)reader[Values.DiscountQuantity];
                            (item as ProcuredItem).OrderCosts = (double)reader[Values.OrderCosts];
                            (item as ProcuredItem).ProcureLeadTime = (double)reader[Values.ProcureLeadTime];
                            (item as ProcuredItem).ProcureLeadTimeDeviation = (double)reader[Values.ProcureLeadTimeDeviation];

                            _ItemCache.Add(item.Id, item);
                        }
                        else if (type == Values.UnfinishedProduct)
                        {
                            item = new UnfinishedProduct();
                            item.Id = (int)reader[Values.Id];
                            item.Description = (string)reader[Values.Description];
                            item.Stock = (int)reader[Values.Stock];
                            item.Value = (double)reader[Values.Value];

                            _ItemCache.Add(item.Id, item);
                        }
                        else if (type == Values.FinishedProduct)
                        {
                            item = new FinishedProduct();
                            item.Id = (int)reader[Values.Id];
                            item.Description = (string)reader[Values.Description];
                            item.Stock = (int)reader[Values.Stock];
                            item.Value = (double)reader[Values.Value];

                            _ItemCache.Add(item.Id, item);
                        }

                    }
                }
            }
        }
        private void _ReadChildsOfProducts(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "select * from " + Values.ChildToProduct;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var child = GetItemById((int)reader[Values.Child_Id]);
                        var product = (Product) GetItemById((int)reader[Values.Product_Id]);

                        product.AddItem(child, (int)reader[Values.Quantity]);
                    }
                }
            }
        }
        private void _ReadWorkplaces(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "select * from " + Values.Workplace;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var id = (int)reader[Values.Id];

                        _WorkplaceCache.Add(id, new Workplace { 
                            Id = id,
                            LaborCostsFirstShift = (double)reader[Values.LaborCostsFirstShift],
                            LaborCostsSecondShift = (double)reader[Values.LaborCostsSecondShift],
                            LaborCostsThirdShift = (double)reader[Values.LaborCostsThirdShift],
                            LaborCostsOvertime = (double)reader[Values.LaborCostsOvertime]
                        });
                    }
                }
            }
        }
        private void _ReadItemJobs(SQLiteConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "select * from " + Values.ItemJob;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var id = (int)reader[Values.Id];

                        var product = (Product)GetItemById((int)reader[Values.Product_Id]);
                        var workplace = GetWorkplaceById((int)reader[Values.Workplace_Id]);

                        var itemJob = new ItemJob { Id = id,
                            Product = product,
                            Workplace = workplace, 
                            ProductionTimePerPiece = (double)reader[Values.ProductionTimePerPiece], 
                            SetupTime = (double)reader[Values.SetupTime] };

                        _ItemJobCache.Add(id, itemJob);

                        workplace.Jobs.Add(itemJob);
                    }
                }
            }
        }
        private void _ReadNextItemJobs(SQLiteConnection conn) 
        {
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "select * from " + Values.ItemJob;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var itemJob = GetItemJobById((int)reader[Values.Id]);
                        try
                        {
                            var nextItemJob = GetItemJobById((int)reader[Values.NextItemJob_Id]);
                            itemJob.NextItemJob = nextItemJob;
                        }
                        catch (InvalidCastException)
                        {
                            itemJob.NextItemJob = null;
                        }
                    }
                }
            }
        }


        public void WriteFixtures() 
        {

            using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = File.ReadAllText(@"Sql\fixtures.sql");
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void CreateSchema()
        {

            using (var conn = new SQLiteConnection(Constants.CONNECTION_URI))
            {
                conn.Open();
                // Create schema
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = File.ReadAllText(@"Sql\schema.sql");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string _GenerateUpdateFromDict(string table, int recordId, Dictionary<string, object> dict)
        {

            List<string> keyValuePairs = new List<string>();

            foreach (var key in dict.Keys)
            {
                if (key == Values.Id)
                {
                    continue;
                }
                else if (dict[key] == null)
                {
                    keyValuePairs.Add(key + "=null");
                }
                else if (dict[key] is string)
                {
                    keyValuePairs.Add(key + "=\"" + dict[key] + "\"");
                }
                else
                {
                    var value = dict[key];
                    if (value == null)
                    {
                        keyValuePairs.Add(key + "=null");
                    }
                    else
                    {
                        keyValuePairs.Add(key + "=" + value.ToString());
                    }
                }

            }

            return "UPDATE " + table + " SET " + String.Join(", ", keyValuePairs) + " WHERE " + Values.Id + "=" + recordId + ";";
        }

        public Item GetItemById(int id)
        {

            if (!_ItemCache.ContainsKey(id))
            {
                return null;
            }
            return _ItemCache[id];
        }

        public Workplace GetWorkplaceById(int id)
        {

            if (!_WorkplaceCache.ContainsKey(id))
            {
                return null;
            }
            return _WorkplaceCache[id];

            
        }


        public List<Workplace> GetAllWorkplaces()
        {
            return new List<Workplace>(_WorkplaceCache.Values);
        }


        public List<ItemJob> GetAllItemJobs()
        {
            return new List<ItemJob>(_ItemJobCache.Values);
        }

        public List<Item> GetAllItems()
        {
            return new List<Item>(_ItemCache.Values);
        }


        public void AppendNextItemJob(int productId, int workplaceId, int nextWorkplaceId)
        {
            var product = (Product) GetItemById(productId);
            var workplace = GetWorkplaceById(workplaceId);
            var nextWorkplace = GetWorkplaceById(nextWorkplaceId);

            var itemJob = GetItemJobByWorkplaceAndProduct(
                    workplace,
                    product
                );

            product = (Product)GetItemById(productId);

            var nextItemJob = 
                GetItemJobByWorkplaceAndProduct(
                    nextWorkplace,
                    product
                );

            AppendNextItemJob(
                ref itemJob,
                nextItemJob
            );
        }

        public void AppendNextItemJob(ref ItemJob itemJob, ItemJob nextItemJob)
        {
            if (itemJob.Id == nextItemJob.Id)
            {
                throw new Exception("Item and next item must not be the same");
            }

            if (itemJob.Product.Id != nextItemJob.Product.Id)
            {
                throw new Exception("Item and next item must produce the same product");
            }
            _ItemJobCache[itemJob.Id].NextItemJob = GetItemJobById(nextItemJob.Id);

        }

        public ItemJob GetItemJobByWorkplaceAndProduct(Workplace workplace, Product product) {
            if (workplace == null) {
                throw new ArgumentException("Workplace is not set");
            }
            if (product == null)
            {
                throw new ArgumentException("Product is not set");
            }

            var allItemJobs = GetAllItemJobs();

            return new List<ItemJob>(from itemJob in allItemJobs where itemJob.Workplace == workplace && itemJob.Product == product select itemJob).FirstOrDefault();
        }

        public ItemJob GetItemJobById(int id)
        {
            if (!_ItemJobCache.ContainsKey(id))
            {
                return null;
            }
            return _ItemJobCache[id];
        }

        public void AddChildToProduct(Product product, Item child, int quantity)
        {
            product.AddItem(child, quantity);
        }

        public void CreateItem(Item item) {

            _ItemCache.Add(item.Id, item);
        }

        public void CreateWorkplace(Workplace workplace)
        {
            _WorkplaceCache.Add(workplace.Id, workplace);
        }

        public void CreateItemJob(ItemJob itemJob)
        {
            if (itemJob.Workplace != null) {
                itemJob.Workplace.Jobs.Add(itemJob);
            }
            _ItemJobCache.Add(itemJob.Id, itemJob);
        }

    }
}
