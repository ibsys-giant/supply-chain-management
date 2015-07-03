using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Util;
using SupplyChainManagement.Data;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement.Services
{
    public class MaterialPlanning
    {
        private SQLiteDataSource _DataSource;
        public SQLiteDataSource DataSource
        {
            get {
                return _DataSource;
            }
        }

        public Dictionary<Product, int> ProductionOrders = new Dictionary<Product, int>();

        public MaterialPlanning(SQLiteDataSource ds)
        {
            this._DataSource = ds;
        }

        public MaterialPlanning CreateProductionOrders(Product product, int demand, int plannedWarehouseStock)
        {

            var whereUsedList = BillOfMaterialUtil.CreateWhereUsedList(product);

            var parentFinishedProducts =
                from whereUsed in whereUsedList
                where whereUsed is FinishedProduct
                select whereUsed;

            var ordersInQueue = GetOrderQuantityInWaitingQueue(product);
            var workInProgress = GetWorkQuantityInProgress(product);

            int availableStock;
            if (parentFinishedProducts.Count() > 0)
            {
                availableStock = (int) (product.Stock / (double)parentFinishedProducts.Count());
            }
            else {
                availableStock = product.Stock;
            }


            var orders = demand + plannedWarehouseStock - availableStock - ordersInQueue - workInProgress;

            if (ProductionOrders.ContainsKey(product))
            {
                ProductionOrders[product] += orders;
            }
            else
            {
                ProductionOrders[product] = orders;
            }

            foreach (Item childItem in product.Items) {

                // Only look at products
                if (childItem is Product) {
                    var childProduct = childItem as Product;

                    var childDemand = demand * product.ItemQuantities[childItem];
                    var plannedChildWarehouseStock = plannedWarehouseStock * product.ItemQuantities[childItem];
                    CreateProductionOrders(childProduct, childDemand, plannedChildWarehouseStock);
                }
            }

            return this;
        }

        public int GetWorkQuantityInProgress(Product product)
        {
            // TODO
            return 0;
        }

        public int GetOrderQuantityInWaitingQueue(Product product)
        {
            // TODO
            return 0;
        }
    }
}
