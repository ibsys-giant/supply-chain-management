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

        public Dictionary<ProcuredItem, ProcurementOrder> ProcurementOrders = new Dictionary<ProcuredItem, ProcurementOrder>();

        public List<int> TotalDemandsForPeriods = new List<int>();

        public ProcurementPlanning(CapacityPlanning cp) : base(cp, cp.AdditionalCapacityRequirements) {
            this.Overtime = cp.Overtime;
            this.Shifts = cp.Shifts;
        }

        public void CreateProcurementOrders()
        {

            var procuredItems = new List<ProcuredItem>(from item in DataSource.GetAllItems() where item is ProcuredItem select item as ProcuredItem);
            var finishedProducts =  new List<FinishedProduct>(from item in DataSource.GetAllItems() where item is FinishedProduct select item as FinishedProduct);
            
            var billsOfMaterials = new Dictionary<FinishedProduct, Dictionary<Item, int>>();
            foreach (var finishedProduct in finishedProducts)
            {
                billsOfMaterials.Add(finishedProduct, BillOfMaterialUtil.CreateBillOfMaterial(finishedProduct));
            }

            foreach (var procuredItem in procuredItems)
            {
                var stock = procuredItem.Stock;
                var sigma = procuredItem.ProcureLeadTimeDeviation;
                var worstCaseArrivalTime = procuredItem.ProcureLeadTime + sigma;
                var worstCaseArrivalPeriod = (int)worstCaseArrivalTime;

                if (worstCaseArrivalPeriod > 4) {
                    worstCaseArrivalPeriod = 4;
                }

                var totalDemandPerProcuredItem = 0.0;

                for (var period = 0; period <= worstCaseArrivalPeriod; period++)
                {
                    foreach (FinishedProduct product in finishedProducts)
                    {
                        try { 
                            var itemPerProduct = billsOfMaterials[product][procuredItem];
                            var productOrders = ProductionOrders[worstCaseArrivalPeriod][product];

                            if (period == worstCaseArrivalPeriod)
                            {
                                totalDemandPerProcuredItem += itemPerProduct * productOrders * (worstCaseArrivalPeriod + 1 - worstCaseArrivalTime);
                            }
                            else
                            {
                                totalDemandPerProcuredItem += itemPerProduct * productOrders;
                            }
                        } catch (KeyNotFoundException) {
                            continue;
                        }
                    }
                }

                if (stock <= (totalDemandPerProcuredItem/2.0))
                {
                    ProcurementOrders.Add(procuredItem, new ProcurementOrder { Type = ProcurementOrder.OrderType.FAST, Quantity = (int) totalDemandPerProcuredItem });
                }
                else if (stock <= totalDemandPerProcuredItem)
                {
                    ProcurementOrders.Add(procuredItem, new ProcurementOrder { Type = ProcurementOrder.OrderType.NORMAL, Quantity = (int)totalDemandPerProcuredItem });
                }
            }
        }
    }
}
