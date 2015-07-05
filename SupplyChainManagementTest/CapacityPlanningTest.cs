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
    public class CapacityPlanningTest
    {
        private string _TestUsername;
        private string _TestPassword;


        public CapacityPlanningTest()
        {

            _TestUsername = Environment.GetEnvironmentVariable("SCM_TEST_USERNAME");
            _TestPassword = Environment.GetEnvironmentVariable("SCM_TEST_PASSWORD");

            Assert.IsNotNullOrEmpty(_TestUsername, "Please set SCM_TEST_USERNAME env variable");
            Assert.IsNotNullOrEmpty(_TestPassword, "Please set SCM_TEST_PASSWORD env variable");
        }


        [TestCase]
        public void CapacityPlanningWorks()
        {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            planner.Sync(166, 2, 5);


            var demands = new List<Dictionary<FinishedProduct, int>>();

            var demandsFirstPeriod = new Dictionary<FinishedProduct, int>();
            demandsFirstPeriod.Add(planner.DataSource.GetItemById(1) as FinishedProduct, 200);
            demandsFirstPeriod.Add(planner.DataSource.GetItemById(2) as FinishedProduct, 150);
            demandsFirstPeriod.Add(planner.DataSource.GetItemById(3) as FinishedProduct, 100);
            demands.Add(demandsFirstPeriod);

            var demandsSecondPeriod = new Dictionary<FinishedProduct, int>();
            demandsSecondPeriod.Add(planner.DataSource.GetItemById(1) as FinishedProduct, 200);
            demandsSecondPeriod.Add(planner.DataSource.GetItemById(2) as FinishedProduct, 150);
            demandsSecondPeriod.Add(planner.DataSource.GetItemById(3) as FinishedProduct, 100);
            demands.Add(demandsSecondPeriod);

            var demandsThirdPeriod = new Dictionary<FinishedProduct, int>();
            demandsThirdPeriod.Add(planner.DataSource.GetItemById(1) as FinishedProduct, 200);
            demandsThirdPeriod.Add(planner.DataSource.GetItemById(2) as FinishedProduct, 150);
            demandsThirdPeriod.Add(planner.DataSource.GetItemById(3) as FinishedProduct, 100);
            demands.Add(demandsThirdPeriod);

            var demandsFourthPeriod = new Dictionary<FinishedProduct, int>();
            demandsFourthPeriod.Add(planner.DataSource.GetItemById(1) as FinishedProduct, 200);
            demandsFourthPeriod.Add(planner.DataSource.GetItemById(2) as FinishedProduct, 150);
            demandsFourthPeriod.Add(planner.DataSource.GetItemById(3) as FinishedProduct, 100);
            demands.Add(demandsFourthPeriod);

            var plannedStocks = new Dictionary<FinishedProduct, int>();
            plannedStocks.Add(planner.DataSource.GetItemById(1) as FinishedProduct, 50);
            plannedStocks.Add(planner.DataSource.GetItemById(2) as FinishedProduct, 50);
            plannedStocks.Add(planner.DataSource.GetItemById(3) as FinishedProduct, 50);

            planner.Plan(demands, plannedStocks);

            Assert.IsNotEmpty(planner.CapacityPlanning.ProductionOrders);
            Assert.IsNotEmpty(planner.CapacityPlanning.TotalCapacityRequirements);

            foreach (double req in planner.CapacityPlanning.TotalCapacityRequirements.Values)
            {
                Assert.Greater(req, 0.0);
            }
        }

        [TestCase]
        public void SimpleCapacityPlanningWorks()
        {
            var dataSource = new SQLiteDataSource();
            var materialPlanning = new MaterialPlanning(dataSource, new Dictionary<Product, int>(), new Dictionary<Product, int>());

            var p1 = materialPlanning.DataSource.GetItemById(1) as Product;
            var p2 = materialPlanning.DataSource.GetItemById(2) as Product;
            var p3 = materialPlanning.DataSource.GetItemById(3) as Product;

            // Create orders
            materialPlanning
                .CreateProductionOrders(p1, 150, 100)
                .CreateProductionOrders(p2, 100, 100)
                .CreateProductionOrders(p3, 100, 100);

            var capacityPlanning = new CapacityPlanning(materialPlanning, new Dictionary<Workplace,double>());
            capacityPlanning.CreateWorkRequirements();


        }
    }
}
