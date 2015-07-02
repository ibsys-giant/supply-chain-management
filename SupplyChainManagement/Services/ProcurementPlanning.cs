using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyChainManagement.Data;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;
using SupplyChainManagement.Util;


namespace SupplyChainManagement.Services
{
    public class ProcurementPlanning : CapacityPlanning
    {

        public List<ProcurementOrder> ProcurementOrders = new List<ProcurementOrder>();

        public List<Dictionary<ProcuredItem, int>> DemandsForPeriods = new List<Dictionary<ProcuredItem, int>>();

        public List<int> TotalDemandsForPeriods = new List<int>();

        public ProcurementPlanning(CapacityPlanning cp) : base(cp) {
            
        }

        public ProcurementPlanning CreateProcurementOrders(List<Dictionary<FinishedProduct, int>> demands) {
            var procuredItems = from item in this.DataSource.GetAllItems()
                                where item is ProcuredItem
                                select item as ProcuredItem;

            var finishedProductProductionOrders = from order in this.ProductionOrders
                                          where order.Key is FinishedProduct
                                          select order;

            foreach (var procuredItem in procuredItems)
            {
                for (int period = 0; period < demands.Count; period++)
                {
                    var demandForCurrentPeriod = new Dictionary<ProcuredItem, int>();
                    var finishedProductsUsedIn = from product in BillOfMaterialUtil.CreateWhereUsedList(procuredItem)
                                                 where product is FinishedProduct
                                                 select product;

                    TotalDemandsForPeriods.Add(0);
                    demandForCurrentPeriod[procuredItem] = 0;

                    foreach (var product in finishedProductsUsedIn)
                    {
                        int totalUsageQuantity = BillOfMaterialUtil.CreateBillOfMaterial(product)[procuredItem];
                        int finishedProductOrderQuantity = (from order in finishedProductProductionOrders
                                                            where order.Key == product
                                                           select order.Value).First<int>();

                        demandForCurrentPeriod[procuredItem] += finishedProductOrderQuantity * totalUsageQuantity;
                        TotalDemandsForPeriods[period] += demandForCurrentPeriod[procuredItem];
                    }

                    DemandsForPeriods.Add(demandForCurrentPeriod);
                }

                // Calculate worst case demand
                var worstCaseLeadTime = procuredItem.ProcureLeadTime + procuredItem.ProcureLeadTimeDeviation;
                var periodsAffected = Math.Ceiling(worstCaseLeadTime);

                var totalDemand = 0;
                for (var period = 0; period < periodsAffected; period++) {
                    totalDemand += TotalDemandsForPeriods[period];
                }
                var worstCaseDemand = (double)(totalDemand * worstCaseLeadTime) / ((double) periodsAffected);

                // Calculate lead case demand
                periodsAffected = Math.Ceiling(procuredItem.ProcureLeadTime);
                totalDemand = 0;
                for (var period = 0; period < periodsAffected; period++) {
                    totalDemand += TotalDemandsForPeriods[period];
                }
                var leadCaseDemand = (double) (totalDemand * procuredItem.ProcureLeadTime) / ((double) periodsAffected);


                var procOrder = new ProcurementOrder();
                procOrder.Item = procuredItem;
                procOrder.Quantity = (int) worstCaseDemand;

                if (procOrder.Quantity < procuredItem.DiscountQuantity)
                {
                    procOrder.Quantity = procuredItem.DiscountQuantity;
                }

                if (leadCaseDemand > procuredItem.Stock)
                {
                    procOrder.Type = ProcurementOrder.OrderType.FAST;
                }
                else 
                {
                    procOrder.Type = ProcurementOrder.OrderType.NORMAL;
                }

                ProcurementOrders.Add(procOrder);
            }

            return this;
        }
    }
}
