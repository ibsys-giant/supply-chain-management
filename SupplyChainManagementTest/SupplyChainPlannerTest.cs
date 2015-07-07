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

        //[TestCase]
        //public void DeserializationShouldWork() {
        //    var planner = new SupplyChainPlanner();
        //    planner.DataSource.Purge();


        //    Assert.AreNotEqual(0, planner.PassedPeriodResult.Game);
        //    Assert.AreNotEqual(0, planner.PassedPeriodResult.Group);
        //    Assert.AreNotEqual(0, planner.PassedPeriodResult.Period);

        //    foreach (var article in planner.PassedPeriodResult.WarehouseStock.Articles)
        //    {
        //        Assert.AreNotEqual(0, article.Id);
        //    }

        //    foreach (var order in planner.PassedPeriodResult.InwardStockMovement.Orders)
        //    {
        //        Assert.AreNotEqual(0, order.Id);
        //    }

        //    foreach (var order in planner.PassedPeriodResult.FutureInwardStockMovement.Orders)
        //    {
        //        Assert.AreNotEqual(0, order.Id);
        //    }

        //    foreach (var workplace in planner.PassedPeriodResult.IdleTimeCosts.Workplaces)
        //    {
        //        Assert.AreNotEqual(0, workplace.Id);
        //    }

        //    foreach (var workplace in planner.PassedPeriodResult.WaitingListWorkstations.Workplaces)
        //    {
        //        Assert.AreNotEqual(0, workplace.Id);
        //    }

        //    var i = 0;
        //    foreach (var part in planner.PassedPeriodResult.WaitingListStock.MissingParts)
        //    {
        //        Assert.AreNotEqual(0, part.Id);

        //        Assert.AreNotEqual(0, planner.PassedPeriodResult.WaitingListStock.MissingParts[i].WaitingLists.Count);
        //        foreach (var waitinglist in planner.PassedPeriodResult.WaitingListStock.MissingParts[i].WaitingLists)
        //        {
        //            Assert.AreNotEqual(0, waitinglist.Period);
        //        }
        //        i++;
        //    }

        //    foreach (var workplace in planner.PassedPeriodResult.OrdersInWork.Workplaces)
        //    {
        //        Assert.AreNotEqual(0, workplace.Id);
        //        Assert.AreNotEqual(0, workplace.Period);
        //        Assert.AreNotEqual(0, workplace.Order);
        //        Assert.AreNotEqual(0, workplace.Batch);
        //    }

        //    foreach (var workplace in planner.PassedPeriodResult.OrdersInWork.Workplaces)
        //    {
        //        Assert.AreNotEqual(0, workplace.Id);
        //        Assert.AreNotEqual(0, workplace.Period);
        //        Assert.AreNotEqual(0, workplace.Order);
        //        Assert.AreNotEqual(0, workplace.Batch);
        //    }

        //    Assert.AreNotEqual(0, planner.PassedPeriodResult.CompletedOrders);
        //    foreach (var workplace in planner.PassedPeriodResult.OrdersInWork.Workplaces)
        //    {
        //        Assert.AreNotEqual(0, workplace.Id);
        //        Assert.AreNotEqual(0, workplace.Period);
        //        Assert.AreNotEqual(0, workplace.Order);
        //        Assert.AreNotEqual(0, workplace.Batch);
        //    }

        //    Assert.AreNotEqual(0, planner.PassedPeriodResult.CycleTimes.Orders.Count);
        //    foreach (var order in planner.PassedPeriodResult.CycleTimes.Orders)
        //    {
        //        Assert.AreNotEqual(0, order.Id);
        //    }

        //}


        [TestCase]
        public void PlanShouldCreateCorrectWaitingList()
        {
            var planner = new SupplyChainPlanner();
            planner.DataSource.Purge();

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

            Assert.IsNotEmpty(planner.WaitingList.Keys);
        }

        [TestCase]
        public void PlanShouldCreateCorrectOrdersInWork()
        {
            var planner = new SupplyChainPlanner();
            planner.DataSource.Purge();

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

        }

        [TestCase]
        public void ExportTest()
        {
            var planner = new SupplyChainPlanner();
            planner.DataSource.Purge();

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

            planner.Export();
        }

        [TestCase]
        public void AdditionalCapacityRequirementsShouldWork()
        {
            var planner = new SupplyChainPlanner();
            planner.DataSource.Purge();

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

        }
    
    
    }
}
