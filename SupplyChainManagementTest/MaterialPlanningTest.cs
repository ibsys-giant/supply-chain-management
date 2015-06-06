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
using SupplyChainManagement.Util;

namespace SupplyChainManagementTest
{
    public class MaterialPlanningTest
    {
        [TestCase]
        public void MaterialPlanningShouldWork()
        {
            var materialPlanning = new MaterialPlanning(new DataSourceMock());

            var p1 = materialPlanning.DataSource.Items[1] as Product;
            var p2 = materialPlanning.DataSource.Items[2] as Product;
            var p3 = materialPlanning.DataSource.Items[3] as Product;

            // E26 is used in all three finished products
            var e26 = materialPlanning.DataSource.Items[26] as Product;

            // Create orders
            materialPlanning
                .CreateProductionOrders(p1, 150, 100)
                .CreateProductionOrders(p2, 100, 100)
                .CreateProductionOrders(p3, 100, 100);


            // Check orders of finished products

            Assert.AreEqual(150, materialPlanning.ProductionOrders[p1]);

            Assert.AreEqual(100, materialPlanning.ProductionOrders[p2]);

            Assert.AreEqual(100, materialPlanning.ProductionOrders[p3]);

            // Check orders of E26

            Assert.AreEqual(350, materialPlanning.ProductionOrders[e26]);
        }


    }
}
