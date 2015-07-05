using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using SupplyChainManagement.Services;

using SupplyChainManagement.Models.ItemManagement;

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

            planner.Import(166, 2, 7);

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

            Assert.AreNotEqual(0, planner.PassedPeriodResult.WaitingListStock.MissingParts.Count);
            var i = 0;
            foreach (var part in planner.PassedPeriodResult.WaitingListStock.MissingParts)
            {
                Assert.AreNotEqual(0, part.Id);

                Assert.AreNotEqual(0, planner.PassedPeriodResult.WaitingListStock.MissingParts[i].WaitingLists.Count);
                foreach (var waitinglist in planner.PassedPeriodResult.WaitingListStock.MissingParts[i].WaitingLists)
                {
                    Assert.AreNotEqual(0, waitinglist.Period);
                }
                i++;
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.OrdersInWork.Workplaces.Count);
            foreach (var workplace in planner.PassedPeriodResult.OrdersInWork.Workplaces)
            {
                Assert.AreNotEqual(0, workplace.Id);
                Assert.AreNotEqual(0, workplace.Period);
                Assert.AreNotEqual(0, workplace.Order);
                Assert.AreNotEqual(0, workplace.Batch);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.OrdersInWork.Workplaces.Count);
            foreach (var workplace in planner.PassedPeriodResult.OrdersInWork.Workplaces)
            {
                Assert.AreNotEqual(0, workplace.Id);
                Assert.AreNotEqual(0, workplace.Period);
                Assert.AreNotEqual(0, workplace.Order);
                Assert.AreNotEqual(0, workplace.Batch);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.CompletedOrders);
            foreach (var workplace in planner.PassedPeriodResult.OrdersInWork.Workplaces)
            {
                Assert.AreNotEqual(0, workplace.Id);
                Assert.AreNotEqual(0, workplace.Period);
                Assert.AreNotEqual(0, workplace.Order);
                Assert.AreNotEqual(0, workplace.Batch);
            }

            Assert.AreNotEqual(0, planner.PassedPeriodResult.CycleTimes.Orders.Count);
            foreach (var order in planner.PassedPeriodResult.CycleTimes.Orders)
            {
                Assert.AreNotEqual(0, order.Id);
            }

        }

        [TestCase]
        public void SyncShouldUpdateStocks()
        {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            var item1StockBefore = planner.DataSource.GetItemById(1).Stock;

            planner.Import(169, 2, 8);

            var item1StockAfter = planner.DataSource.GetItemById(1).Stock;

            Assert.AreNotEqual(item1StockBefore, item1StockAfter);
        }


        [TestCase]
        public void PlanShouldCreateCorrectWaitingList()
        {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            planner.Import(166, 2, 5);

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

            Assert.IsNotEmpty(planner.WaitingList.Keys);
        }

        [TestCase]
        public void PlanShouldCreateCorrectOrdersInWork()
        {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            planner.Import(166, 2, 5);

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

            Assert.IsNotEmpty(planner.OrdersInWork.Keys);
        }

        [TestCase]
        public void ExportTest()
        {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            planner.Import(166, 2, 5);


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

            planner.Export();
        }

        [TestCase]
        public void AdditionalCapacityRequirementsShouldWork()
        {
            var planner = new SupplyChainPlanner(new Uri("http://scsim-phoenix.de:8080"), _TestUsername, _TestPassword);
            planner.DataSource.Purge();

            planner.Import(166, 2, 5);


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

            Assert.IsNotEmpty(planner.AdditionalCapacityRequirements.Keys);

        }
    
    
    }
}
