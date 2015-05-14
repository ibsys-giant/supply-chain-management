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
                .CreateProductionOrders(p2, 150, 100)
                .CreateProductionOrders(p3, 150, 100);


            int totalOrders;

            // Check orders of finished products

            totalOrders = materialPlanning.CalculateTotalOrdersForProduct(p1);
            Assert.AreEqual(150, totalOrders);

            totalOrders = materialPlanning.CalculateTotalOrdersForProduct(p2);
            Assert.AreEqual(150, totalOrders);

            totalOrders = materialPlanning.CalculateTotalOrdersForProduct(p3);
            Assert.AreEqual(150, totalOrders);

            // Check orders of E26

            totalOrders = materialPlanning.CalculateTotalOrdersForProduct(e26);
            Assert.AreEqual(450, totalOrders);
        }


    }
}
