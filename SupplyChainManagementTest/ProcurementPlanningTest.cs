

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using SupplyChainManagement;
using SupplyChainManagement.Data;
using SupplyChainManagement.Services;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagementTest
{
    public class ProcurementPlanningTest
    {


        [TestCase]
        public void ProcurementPlanningWorks()
        {
            var dataSource = new SQLiteDataSource();
            var materialPlanning = new MaterialPlanning(dataSource);

            var p1 = materialPlanning.DataSource.GetItemById(1) as FinishedProduct;
            var p2 = materialPlanning.DataSource.GetItemById(2) as FinishedProduct;
            var p3 = materialPlanning.DataSource.GetItemById(3) as FinishedProduct;

            // Create orders
            materialPlanning
                .CreateProductionOrders(p1, 150, 100)
                .CreateProductionOrders(p2, 150, 100)
                .CreateProductionOrders(p3, 150, 100);

            var capacityPlanning = new CapacityPlanning(materialPlanning);
            capacityPlanning = capacityPlanning.CreateWorkRequirements();

            var procurementPlanning = new ProcurementPlanning(capacityPlanning);

            var demands = new List<Dictionary<FinishedProduct, int>>();

            var demandsFirstPeriod = new Dictionary<FinishedProduct, int>();
            demandsFirstPeriod[p1] = 150;
            demandsFirstPeriod[p2] = 150;
            demandsFirstPeriod[p3] = 150;
            demands.Add(demandsFirstPeriod);

            var demandsSecondPeriod = new Dictionary<FinishedProduct, int>();
            demandsSecondPeriod[p1] = 150;
            demandsSecondPeriod[p2] = 100;
            demandsSecondPeriod[p3] = 100;
            demands.Add(demandsSecondPeriod);

            var demandsThirdPeriod = new Dictionary<FinishedProduct, int>();
            demandsThirdPeriod[p1] = 150;
            demandsThirdPeriod[p2] = 100;
            demandsThirdPeriod[p3] = 50;
            demands.Add(demandsThirdPeriod);

            var demandsFourthPeriod = new Dictionary<FinishedProduct, int>();
            demandsFourthPeriod[p1] = 150;
            demandsFourthPeriod[p2] = 50;
            demandsFourthPeriod[p3] = 50;
            demands.Add(demandsFourthPeriod);

            procurementPlanning.CreateProcurementOrders(demands);

            Assert.AreNotEqual(0, procurementPlanning.DemandsForPeriods.Count);
            Assert.AreNotEqual(0, procurementPlanning.ProcurementOrders.Count);
        }
    }
}
