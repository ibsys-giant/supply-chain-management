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

            planner.Import(new Uri("http://scsim-phoenix.de:8080/scs/data/output/169_2_8result.xml"));

            var p1 = planner.DataSource.GetItemById(1) as FinishedProduct;
            var p2 = planner.DataSource.GetItemById(2) as FinishedProduct;
            var p3 = planner.DataSource.GetItemById(3) as FinishedProduct;

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
            var dataSource = new ORM();
            dataSource.Purge();
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
