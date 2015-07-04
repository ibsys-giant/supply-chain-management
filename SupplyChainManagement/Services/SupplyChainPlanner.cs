using SupplyChainManagement.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Xml;
using System.Xml.Serialization;

using SupplyChainManagement.Models.Xml;
using System.Net;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Services
{
    public class SupplyChainPlanner
    {
        public readonly SQLiteDataSource DataSource;
        public readonly SimulatorClient Client;

        public PeriodResult PassedPeriodResult;

        public Dictionary<Product, int> WaitingList = new Dictionary<Product, int>();
        public Dictionary<Product, int> OrdersInWork = new Dictionary<Product, int>();

        public MaterialPlanning MaterialPlanning;
        

        public SupplyChainPlanner(Uri endpoint, string username, string password, WebProxy proxy = null) 
        {
            DataSource = new SQLiteDataSource();
            Client = new SimulatorClient(endpoint, proxy);
            Client.Login(username, password);
        }

        public void Sync(int game, int group, int period) 
        {
            Debug.WriteLine("Reading XML file...");
            string xml = Client.ReadResult(game, group, period);

            XmlSerializer serializer = new XmlSerializer(typeof(PeriodResult));

            using (TextReader reader = new StringReader(xml)) {
                PassedPeriodResult = (PeriodResult) serializer.Deserialize(reader);
            }

            foreach (var article in PassedPeriodResult.WarehouseStock.Articles) {
                var item = DataSource.GetItemById(article.Id);

                item.Stock = article.Amount;
                item.Value = article.Price;

                DataSource.UpdateItem(ref item);
            }
        }

        public void Plan(Dictionary<FinishedProduct, int> demands, Dictionary<FinishedProduct, int> plannedWarehouseStocks) {


            var allProducts = new List<Product>(from item in DataSource.GetAllItems() where item is Product select item as Product);
            var allFinishedProducts = new List<FinishedProduct>(from item in DataSource.GetAllItems() where item is FinishedProduct select item as FinishedProduct);

            // Retrieve workplaces from waiting list out of XML
            var workplaces = PassedPeriodResult.WaitingListWorkstations.Workplaces;

            foreach (var workplace in workplaces) {
                if (workplace.WaitingList != null) {
                    var product = DataSource.GetItemById(workplace.WaitingList.Item) as Product;

                    if (WaitingList.ContainsKey(product))
                    {
                        WaitingList[product] += workplace.WaitingList.Amount;
                    }
                    else
                    {
                        WaitingList[product] = workplace.WaitingList.Amount;
                    }
                }
            }

            // Do material planning

            MaterialPlanning = new MaterialPlanning(DataSource, WaitingList, OrdersInWork);

            foreach (var finishedProduct in allFinishedProducts) {
                MaterialPlanning.CreateProductionOrders(finishedProduct, demands[finishedProduct], plannedWarehouseStocks[finishedProduct]);
            }

            
            // Do capacity planning
        }
    }
}
