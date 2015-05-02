using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

using SupplyChainManagement;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;

namespace SupplyChainManagementTest
{
    [TestClass]
    public class DataSourceMockTest
    {

        [TestMethod]
        public void P1BillOfMaterialShouldBeCorrect()
        {
            DataSource ds = new DataSourceMock();
            var item = ds.Items[1];

            // Produced item 4 must have 34 distinct items
            Assert.AreNotEqual(item.SummarizedItemQuantities.Count, 0);
            Assert.AreEqual(34, item.SummarizedItemQuantities.Count);

            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[4]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[7]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[10]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[13]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[16]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[17]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[18]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[26]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[49]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[50]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[51]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[21]]);
            Assert.AreEqual(7, item.SummarizedItemQuantities[ds.Items[24]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[25]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[27]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[28]]);
            Assert.AreEqual(3, item.SummarizedItemQuantities[ds.Items[32]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[35]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[36]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[37]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[38]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[39]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[40]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[41]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[42]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[43]]);
            Assert.AreEqual(3, item.SummarizedItemQuantities[ds.Items[44]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[45]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[46]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[47]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[48]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[52]]);
            Assert.AreEqual(72, item.SummarizedItemQuantities[ds.Items[53]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[59]]);
        }

        [TestMethod]
        public void P2BillOfMaterialShouldBeCorrect()
        {
            DataSource ds = new DataSourceMock();
            var item = ds.Items[2];

            // Product 2 must have 34 distinct items
            Assert.AreNotEqual(item.SummarizedItemQuantities.Count, 0);
            Assert.AreEqual(34, item.SummarizedItemQuantities.Count);

            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[5]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[8]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[11]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[14]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[16]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[17]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[19]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[26]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[54]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[55]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[56]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[22]]);
            Assert.AreEqual(7, item.SummarizedItemQuantities[ds.Items[24]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[25]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[27]]);
            Assert.AreEqual(5, item.SummarizedItemQuantities[ds.Items[28]]);
            Assert.AreEqual(3, item.SummarizedItemQuantities[ds.Items[32]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[35]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[36]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[37]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[38]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[39]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[40]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[41]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[42]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[43]]);
            Assert.AreEqual(3, item.SummarizedItemQuantities[ds.Items[44]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[45]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[46]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[5]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[47]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[48]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[57]]);
            Assert.AreEqual(72, item.SummarizedItemQuantities[ds.Items[58]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[59]]);

        }

        [TestMethod]
        public void P3BillOfMaterialShouldBeCorrect()
        {
            DataSource ds = new DataSourceMock();
            var item = ds.Items[3];

            // Product 3 must have 34 distinct items
            Assert.AreNotEqual(item.SummarizedItemQuantities.Count, 0);
            Assert.AreEqual(34, item.SummarizedItemQuantities.Count);

            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[6]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[9]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[12]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[15]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[16]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[17]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[20]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[26]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[29]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[30]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[31]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[23]]);
            Assert.AreEqual(7, item.SummarizedItemQuantities[ds.Items[24]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[25]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[27]]);
            Assert.AreEqual(6, item.SummarizedItemQuantities[ds.Items[28]]);
            Assert.AreEqual(3, item.SummarizedItemQuantities[ds.Items[32]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[33]]);
            Assert.AreEqual(72, item.SummarizedItemQuantities[ds.Items[34]]);
            Assert.AreEqual(4, item.SummarizedItemQuantities[ds.Items[35]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[36]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[37]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[38]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[39]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[40]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[41]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[42]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[43]]);
            Assert.AreEqual(3, item.SummarizedItemQuantities[ds.Items[44]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[45]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[46]]);
            Assert.AreEqual(1, item.SummarizedItemQuantities[ds.Items[47]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[48]]);
            Assert.AreEqual(2, item.SummarizedItemQuantities[ds.Items[59]]);
        }


        [TestMethod]
        public void HasCorrectTotalStock() {
            DataSource ds = new DataSourceMock();
            var expectedTotalStockValue = 289555.0;

            var totalStock = 0.0;

            foreach (Item item in ds.Items.Values) {
                totalStock += item.Stock * item.Value;
            }

            Assert.AreEqual(expectedTotalStockValue, totalStock);
        }

        [TestMethod]
        public void HasCorrectOrderCostCheckSum()
        {
            DataSource ds = new DataSourceMock();
            var expectedOrderCostCheckSum = 1700.0;

            var orderCostCheckSum = 0.0;

            foreach (Item item in ds.Items.Values)
            {
                if (item is ProcurementItem)
                {
                    orderCostCheckSum += (item as ProcurementItem).OrderCosts;
                }
            }

            Assert.AreEqual(expectedOrderCostCheckSum, orderCostCheckSum);
        }

        [TestMethod]
        public void HasCorrectProcurementLeadTimeCheckSum()
        {
            DataSource ds = new DataSourceMock();
            var expectedProcurementLeadTimeCheckSum = 44.11;

            var procurementLeadTimeCheckSum = 0.0;

            foreach (Item item in ds.Items.Values)
            {
                if (item is ProcurementItem)
                {
                    procurementLeadTimeCheckSum += (item as ProcurementItem).ProcureLeadTime;
                }
            }

            Assert.AreEqual(expectedProcurementLeadTimeCheckSum, procurementLeadTimeCheckSum);
        }

        [TestMethod]
        public void HasCorrectProcurementLeadTimeDeviationCheckSum()
        {
            DataSource ds = new DataSourceMock();
            var expectedProcurementLeadTimeDeviationCheckSum = 8.8;

            var procurementLeadTimeDeviationCheckSum = 0.0;

            foreach (Item item in ds.Items.Values)
            {
                if (item is ProcurementItem)
                {
                    procurementLeadTimeDeviationCheckSum += (item as ProcurementItem).ProcureLeadTimeDeviation;
                }
            }

            Assert.AreEqual(expectedProcurementLeadTimeDeviationCheckSum, procurementLeadTimeDeviationCheckSum);
        }

        [TestMethod]
        public void ProcurementItemsMustNotHaveBOMItems()
        {
            DataSource ds = new DataSourceMock();

            foreach (Item item in ds.Items.Values) {
                if (item is ProcurementItem) {
                    Assert.AreEqual(item.SummarizedItemQuantities.Count, 0);
                }
            }
        }

        [TestMethod]
        public void ProductsAndProducedItemsMustHaveBOMItems() {

            DataSource ds = new DataSourceMock();

            foreach (Item item in ds.Items.Values)
            {
                if (item is ProducedItem)
                {
                    Assert.AreNotEqual(item.SummarizedItemQuantities.Count, 0);
                }
                if (item is ProductItem)
                {
                    Assert.AreNotEqual(item.SummarizedItemQuantities.Count, 0);
                }
            }
        }

    }
}
