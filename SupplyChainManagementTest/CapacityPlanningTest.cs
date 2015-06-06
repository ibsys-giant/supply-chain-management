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
            var materialPlanning = new MaterialPlanning(new DataSourceMock());

            var p1 = materialPlanning.DataSource.Items[1] as Product;
            var p2 = materialPlanning.DataSource.Items[2] as Product;
            var p3 = materialPlanning.DataSource.Items[3] as Product;

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
            var dataSource = new DataSourceMock();
            var materialPlanning = new MaterialPlanning(dataSource);

            var p1 = materialPlanning.DataSource.Items[1] as Product;
            var p2 = materialPlanning.DataSource.Items[2] as Product;
            var p3 = materialPlanning.DataSource.Items[3] as Product;

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
