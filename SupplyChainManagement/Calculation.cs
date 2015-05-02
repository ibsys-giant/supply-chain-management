using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagement
{
    public class Calculation
    {
        public List<Order<ProductItem>> ProductDemands = new List<Order<ProductItem>>();
        public List<Order<ProducedItem>> ProductionOrders = new List<Order<ProducedItem>>();
        public List<Order<ProcurementItem>> ProcurementOrders = new List<Order<ProcurementItem>>();

        private Calculation() { }

        public static Calculation NewModel() {
            return new Calculation();
        }

        public Calculation CalculateMaterial(Item item, int demand, int plannedWarehouseStock)
        {
            if (item is ProductItem)
            {
                ProductDemands.Add(new Order<ProductItem> { Item = item as ProductItem, Amount = demand });
            }
            if (item is ProducedItem)
            {
                ProductionOrders.Add(new Order<ProducedItem> { Item = item as ProducedItem, Amount = demand });
            }
            if (item is ProcurementItem)
            {
                ProcurementOrders.Add(new Order<ProcurementItem> { Item = item as ProcurementItem, Amount = demand });
            }

            if (item.ChildItemList == null || item.ChildItemList.Items.Count == 0) { 
                foreach (Item child in item.ChildItemList.Items.Keys) {
                    var childAmount = item.ChildItemList.Items[child];
                    var childDemand = demand * childAmount;
                    var childPlannedWarehouseStock = plannedWarehouseStock * childAmount;
                    CalculateMaterial(child, childDemand, childPlannedWarehouseStock);
                }
            }

            return this;
        }
    }
}
