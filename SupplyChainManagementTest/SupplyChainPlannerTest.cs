using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using SupplyChainManagement.Services;

namespace SupplyChainManagementTest
{
    public class SupplyChainPlannerTest
    {

        private string _TestUsername;
        private string _TestPassword;


        public SupplyChainPlannerTest() {

            _TestUsername = Environment.GetEnvironmentVariable("SCM_TEST_USERNAME");
            _TestPassword = Environment.GetEnvironmentVariable("SCM_TEST_PASSWORD");

            Assert.IsNotNullOrEmpty(_TestUsername, "Please set SCM_TEST_USERNAME env variable");
            Assert.IsNotNullOrEmpty(_TestPassword, "Please set SCM_TEST_PASSWORD env variable");
        }

        [TestCase]
        public void DeserializationShouldWork() {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            planner.Sync(166, 2, 7);

            Assert.AreNotEqual(0, planner.PassedPeriodResult.Game);
            Assert.AreNotEqual(0, planner.PassedPeriodResult.Group);
            Assert.AreNotEqual(0, planner.PassedPeriodResult.Period);

            Assert.AreNotEqual(0, planner.PassedPeriodResult.WarehouseStock.Articles.Count);
            foreach (var article in planner.PassedPeriodResult.WarehouseStock.Articles)
            {
                Assert.AreNotEqual(0, article.Id);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.InwardStockMovement.Orders.Count);
            foreach (var order in planner.PassedPeriodResult.InwardStockMovement.Orders)
            {
                Assert.AreNotEqual(0, order.Id);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.FutureInwardStockMovement.Orders.Count);
            foreach (var order in planner.PassedPeriodResult.FutureInwardStockMovement.Orders)
            {
                Assert.AreNotEqual(0, order.Id);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.IdleTimeCosts.Workplaces.Count);
            foreach (var workplace in planner.PassedPeriodResult.IdleTimeCosts.Workplaces)
            {
                Assert.AreNotEqual(0, workplace.Id);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.WaitingListWorkstations.Workplaces.Count);
            foreach (var workplace in planner.PassedPeriodResult.WaitingListWorkstations.Workplaces)
            {
                Assert.AreNotEqual(0, workplace.Id);
            }

        }
    }
}
