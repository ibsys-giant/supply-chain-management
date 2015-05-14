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
    public class CalculationTest
    {

        [TestCase]
        public void NewCalcluationReturnsNotNull() {
            Assert.IsNotNull(new MaterialPlanning(new DataSourceMock()));
        }

        [TestCase]
        public void MaterialPlanningShouldWork()
        {
            var calc = new MaterialPlanning(new DataSourceMock());

            var p1 = calc.DataSource.Items[1] as Product;
            var e26 = calc.DataSource.Items[26] as Product;

            calc = calc.CreateProductionOrders(p1, 150, 100);

            var totalOrders = calc.CalculateTotalOrdersForProduct(p1);
            Assert.AreEqual(150, totalOrders);


            totalOrders = calc.CalculateTotalOrdersForProduct(e26);
            Assert.AreEqual(150, totalOrders);
        }


    }
}
