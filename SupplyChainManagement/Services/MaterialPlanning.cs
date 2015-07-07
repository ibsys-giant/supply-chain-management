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
        public readonly ORM DataSource;
        public readonly Dictionary<Product, int> WaitingList;
        public readonly Dictionary<Product, int> OrdersInWork;
        public Dictionary<int, Dictionary<Product, int>> ProductionOrders = new Dictionary<int, Dictionary<Product, int>>();

        public MaterialPlanning(ORM ds,
            Dictionary<Product, int> waitingList,
            Dictionary<Product, int> ordersInWork)
        {
            this.DataSource = ds;
            this.WaitingList = waitingList;
            this.OrdersInWork = ordersInWork;
        }


        public void CreateProductionOrders(List<FinishedProduct> finishedProducts, Dictionary<FinishedProduct, List<int>> demands, Dictionary<FinishedProduct, int> plannedWarehouseStocks)
        {
            var periods = 4;

            for (var period = 0; period < periods; period++) 
            {
                ProductionOrders[period] = new Dictionary<Product, int>();
                foreach (var product in finishedProducts) {
                    _CreateProductionOrdersForSingleProduct(product, period, demands[product][period], plannedWarehouseStocks[product]);
                }
            }
        }

        private void _CreateProductionOrdersForSingleProduct(Product product, int period, int demand, int plannedWarehouseStock)
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
                ordersInQueue = (int) ((double) ordersInQueue / (double)parentFinishedProducts.Count());
                workInProgress = (int)((double) workInProgress / (double)parentFinishedProducts.Count());
                availableStock = (int)((double) product.Stock / (double)parentFinishedProducts.Count());
            }
            else {
                availableStock = product.Stock;
            }


            var orders = demand + plannedWarehouseStock - availableStock - ordersInQueue - workInProgress;

            if (ProductionOrders[period].ContainsKey(product))
            {
                ProductionOrders[period][product] += orders;
            }
            else
            {
                ProductionOrders[period][product] = orders;
            }

            foreach (Item childItem in product.Items) {
                if (childItem is Product) {
                    var childProduct = childItem as Product;

                    var childDemand = demand * product.ItemQuantities[childItem];
                    var plannedChildWarehouseStock = plannedWarehouseStock * product.ItemQuantities[childItem];
                    _CreateProductionOrdersForSingleProduct(childProduct, period, childDemand, plannedChildWarehouseStock);
                }
            }
        }
    }
}
