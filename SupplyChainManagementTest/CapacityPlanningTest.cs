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

        [TestCase]
        public void CapacityPlanningWorks()
        {
            var materialPlanning = new MaterialPlanning(new SQLiteDataSource(), new Dictionary<Product, int>(), new Dictionary<Product, int>());

            var p1 = materialPlanning.DataSource.GetItemById(1) as Product;
            var p2 = materialPlanning.DataSource.GetItemById(2) as Product;
            var p3 = materialPlanning.DataSource.GetItemById(3) as Product;

            // Create orders
            materialPlanning
                .CreateProductionOrders(p1, 150, 100)
                .CreateProductionOrders(p2, 100, 100)
                .CreateProductionOrders(p3, 100, 100);

            var capacityPlanning = new CapacityPlanning(materialPlanning);

            Assert.IsNotEmpty(capacityPlanning.ProductionOrders);
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

            var capacityPlanning = new CapacityPlanning(materialPlanning);
            capacityPlanning.CreateWorkRequirements();


        }
    }
}
