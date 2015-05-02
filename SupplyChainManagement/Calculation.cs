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
        private DataSource _DataSource;
        public DataSource DataSource {
            get {
                return _DataSource;
            }
        }

        public List<Order<ProductItem>> ProductDemands = new List<Order<ProductItem>>();
        public List<Order<ProducedItem>> ProductionOrders = new List<Order<ProducedItem>>();
        public List<Order<ProcurementItem>> ProcurementOrders = new List<Order<ProcurementItem>>();

        private Calculation(DataSource ds) {
            this._DataSource = ds;
        }

        public static Calculation NewCalculation(DataSource ds) {
            return new Calculation(ds);
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

            return this;
        }
    }
}
