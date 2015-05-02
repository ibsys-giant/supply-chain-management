using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement
{
    public class Calculation
    {
        private DataSource _DataSource;
        public DataSource DataSource {
            get {
                return _DataSource;
            }
        }

        public List<Order<Product>> ProductionOrders = new List<Order<Product>>();
        public List<Order<ProcuredItem>> ProcurementOrders = new List<Order<ProcuredItem>>();

        private Calculation(DataSource ds) {
            this._DataSource = ds;
        }

        public static Calculation NewCalculation(DataSource ds) {
            return new Calculation(ds);
        }

        public Calculation CreateProductionOrders(FinishedProduct product, int demand, int plannedWarehouseStock)
        {
            
            ProductionOrders.Add(new Order<Product> { Item = product, Quantity = demand - plannedWarehouseStock });

            foreach (Item childItem in product.Items) {

                // Only look at products
                if (childItem is Product) {
                    var childProduct = childItem as Product;
                    var whereUsedList = CreateWhereUsedList(childProduct);

                    var finishedProducts = 
                        from whereUsed in whereUsedList
                        where whereUsed.Key is FinishedProduct
                        select whereUsed.Key;

                    var childDemand = demand * product.ItemQuantities[childItem];
                    //var plannedChildWarehouseStock = ???;
                    var availableWarehouseStock = childItem.Stock / (double) finishedProducts.Count();
                    
                    //CreateProductionOrders(childProduct, 
                }
            }

            return this;
        }

        public static Dictionary<Item, int> CreateBillOfMaterial(Product product)
        {
            return CreateBillOfMaterial(1, product, new Dictionary<Item, int>());
        }

        public static Dictionary<Item, int> CreateBillOfMaterial(int parentQuantity, Product product, Dictionary<Item, int> bom)
        {
            foreach (Item child in product.Items)
            {
                var total = parentQuantity * product.ItemQuantities[child];
                if (bom.ContainsKey(child))
                {
                    bom[child] += total;
                }
                else
                {
                    bom.Add(child, total);
                }

                if (child is Product) {
                    CreateBillOfMaterial(product.ItemQuantities[child], child as Product, bom);
                }
            }
            return bom;
        }

        public static Dictionary<Product, int> CreateWhereUsedList(Item item)
        {
            return CreateWhereUsedList(item, new Dictionary<Product, int>());
        }

        public static Dictionary<Product, int> CreateWhereUsedList(Item item, Dictionary<Product, int> whereUsedList) {

            foreach (Product parent in item.UsedInProducts)
            {
                var quantityUsedInParent = item.UsageQuantities[parent];
                if (whereUsedList.ContainsKey(parent))
                {
                    whereUsedList[parent] += quantityUsedInParent;
                }
                else
                {
                    whereUsedList.Add(parent, quantityUsedInParent);
                }

                CreateWhereUsedList(parent as Product, whereUsedList);
            }

            return whereUsedList;
        }
    }
}
