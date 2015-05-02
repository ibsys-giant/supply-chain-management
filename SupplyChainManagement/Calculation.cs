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

        public Calculation CreateProductionOrders(Product product, int demand, int plannedWarehouseStock)
        {
            
            ProductionOrders.Add(new Order<Product> { Item = product, Quantity = demand - plannedWarehouseStock });

            foreach (Item childItem in product.Items) {

                if (childItem is Product) {
                    var childProduct = childItem as Product;
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
                    bom = CreateBillOfMaterial(product.ItemQuantities[child], child as Product, bom);
                }
            }
            return bom;
        }
    }
}
