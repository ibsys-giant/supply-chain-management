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
        public readonly SQLiteDataSource DataSource;
        public readonly Dictionary<Product, int> WaitingList;
        public readonly Dictionary<Product, int> OrdersInWork;
        public Dictionary<Product, int> ProductionOrders = new Dictionary<Product, int>();

        public MaterialPlanning(SQLiteDataSource ds,
            Dictionary<Product, int> waitingList,
            Dictionary<Product, int> ordersInWork)
        {
            this.DataSource = ds;
            this.WaitingList = waitingList;
            this.OrdersInWork = ordersInWork;
        }

        public MaterialPlanning CreateProductionOrders(Product product, int demand, int plannedWarehouseStock)
        {

            var whereUsedList = BillOfMaterialUtil.CreateWhereUsedList(product);

            var parentFinishedProducts =
                from whereUsed in whereUsedList
                where whereUsed is FinishedProduct
                select whereUsed;

            int ordersInQueue = 0; 
            var workInProgress = 0;

            if (WaitingList.ContainsKey(product)) 
            {
                ordersInQueue = WaitingList[product];
            }
            if (OrdersInWork.ContainsKey(product))
            {
                workInProgress = OrdersInWork[product];
            }


            int availableStock;
            if (parentFinishedProducts.Count() > 0)
            {
                ordersInQueue = (int) (ordersInQueue / (double)parentFinishedProducts.Count());
                workInProgress = (int) (workInProgress / (double)parentFinishedProducts.Count());
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
    }
}
