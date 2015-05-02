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
        public void TestBillOfMaterial()
        {
            DataSource ds = new DataSourceMock();

            // Produced item 4 must have 34 distinct items
            Assert.AreNotEqual(ds.Items[1].BillOfMaterial.Count, 0);
            Assert.AreEqual(ds.Items[1].BillOfMaterial.Count, 34);

            Assert.AreEqual(ds.Items[4].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[7].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[10].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[13].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[16].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[17].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[18].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[26].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[49].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[50].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[51].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[21].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[24].BillOfMaterial.Count, 7);
            Assert.AreEqual(ds.Items[25].BillOfMaterial.Count, 4);
            Assert.AreEqual(ds.Items[27].BillOfMaterial.Count, 2);
            Assert.AreEqual(ds.Items[28].BillOfMaterial.Count, 4);
            Assert.AreEqual(ds.Items[32].BillOfMaterial.Count, 3);
            Assert.AreEqual(ds.Items[35].BillOfMaterial.Count, 4);
            Assert.AreEqual(ds.Items[36].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[37].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[38].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[39].BillOfMaterial.Count, 2);
            Assert.AreEqual(ds.Items[40].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[41].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[42].BillOfMaterial.Count, 2);
            Assert.AreEqual(ds.Items[43].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[44].BillOfMaterial.Count, 3);
            Assert.AreEqual(ds.Items[45].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[46].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[47].BillOfMaterial.Count, 1);
            Assert.AreEqual(ds.Items[48].BillOfMaterial.Count, 2);
            Assert.AreEqual(ds.Items[52].BillOfMaterial.Count, 2);
            Assert.AreEqual(ds.Items[53].BillOfMaterial.Count, 72);
            Assert.AreEqual(ds.Items[59].BillOfMaterial.Count, 2);
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
        public void ProcurementItemsMustNotHaveBOMItems()
        {
            DataSource ds = new DataSourceMock();

            foreach (Item item in ds.Items.Values) {
                if (item is ProcurementItem) {
                    Assert.AreEqual(item.BillOfMaterial.Count, 0);
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
                    Assert.AreNotEqual(item.BillOfMaterial.Count, 0);
                }
                if (item is ProductItem)
                {
                    Assert.AreNotEqual(item.BillOfMaterial.Count, 0);
                }
            }
        }

    }
}
