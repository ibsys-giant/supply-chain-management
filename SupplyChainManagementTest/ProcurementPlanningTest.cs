

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
            var dataSource = new ORM();
            dataSource.Purge();
            var materialPlanning = new MaterialPlanning(dataSource, 
                new Dictionary<Product, int>(),
                new Dictionary<Product, int>());

            var p1 = materialPlanning.DataSource.GetItemById(1) as FinishedProduct;
            var p2 = materialPlanning.DataSource.GetItemById(2) as FinishedProduct;
            var p3 = materialPlanning.DataSource.GetItemById(3) as FinishedProduct;

            // Create orders
            materialPlanning
                .CreateProductionOrders(p1, 150, 100)
                .CreateProductionOrders(p2, 150, 100)
                .CreateProductionOrders(p3, 150, 100);

            var capacityPlanning = new CapacityPlanning(materialPlanning, new Dictionary<Workplace,double>());
            capacityPlanning = capacityPlanning.CreateWorkRequirements();

            var procurementPlanning = new ProcurementPlanning(capacityPlanning);

            var demands = new Dictionary<FinishedProduct, List<int>>();

            var demandsP1 = new List<int>();
            demandsP1.Add(150);
            demandsP1.Add(150);
            demandsP1.Add(150);
            demandsP1.Add(150);
            demands.Add(p1, demandsP1);

            var demandsP2 = new List<int>();
            demandsP2.Add(150);
            demandsP2.Add(100);
            demandsP2.Add(100);
            demandsP2.Add(50);
            demands.Add(p2, demandsP2);

            var demandsP3 = new List<int>();
            demandsP3.Add(100);
            demandsP3.Add(100);
            demandsP3.Add(50);
            demandsP3.Add(50);
            demands.Add(p3, demandsP3);

            procurementPlanning.CreateProcurementOrders(demands);

            Assert.AreNotEqual(0, procurementPlanning.DemandsForPeriods.Count);
            Assert.AreNotEqual(0, procurementPlanning.ProcurementOrders.Count);
        }
    }
}
