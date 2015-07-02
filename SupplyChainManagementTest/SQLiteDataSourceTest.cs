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
    public class SQLiteDataSourceTest
    {

        [TestCase]
        public void ReferenceTest()
        {

            var ds = new SQLiteDataSource();
            ds.Purge();
            Assert.AreSame(ds.GetItemById(24), ds.GetItemById(24));
        }


        [TestCase]
        public void P1BillOfMaterialShouldBeCorrect()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var billOfMaterial = BillOfMaterialUtil.CreateBillOfMaterial(ds.GetItemById(1) as Product);

            // Produced item 4 must have 34 distinct items
            Assert.AreNotEqual(billOfMaterial.Count, 0);
            Assert.AreEqual(34, billOfMaterial.Count);

            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(4)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(7)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(10)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(13)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(16)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(17)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(18)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(26)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(49)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(50)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(51)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(21)]);
            Assert.AreEqual(7, billOfMaterial[ds.GetItemById(24)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(25)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(27)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(28)]);
            Assert.AreEqual(3, billOfMaterial[ds.GetItemById(32)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(35)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(36)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(37)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(38)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(39)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(40)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(41)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(42)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(43)]);
            Assert.AreEqual(3, billOfMaterial[ds.GetItemById(44)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(45)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(46)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(47)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(48)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(52)]);
            Assert.AreEqual(72, billOfMaterial[ds.GetItemById(53)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(59)]);
        }

        [TestCase]
        public void P2BillOfMaterialShouldBeCorrect()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var billOfMaterial = BillOfMaterialUtil.CreateBillOfMaterial(ds.GetItemById(2) as Product);

            // Product 2 must have 34 distinct items
            Assert.AreNotEqual(billOfMaterial.Count, 0);
            Assert.AreEqual(34, billOfMaterial.Count);

            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(5)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(8)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(11)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(14)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(16)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(17)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(19)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(26)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(54)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(55)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(56)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(22)]);
            Assert.AreEqual(7, billOfMaterial[ds.GetItemById(24)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(25)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(27)]);
            Assert.AreEqual(5, billOfMaterial[ds.GetItemById(28)]);
            Assert.AreEqual(3, billOfMaterial[ds.GetItemById(32)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(35)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(36)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(37)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(38)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(39)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(40)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(41)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(42)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(43)]);
            Assert.AreEqual(3, billOfMaterial[ds.GetItemById(44)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(45)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(46)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(5)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(47)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(48)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(57)]);
            Assert.AreEqual(72, billOfMaterial[ds.GetItemById(58)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(59)]);

        }

        [TestCase]
        public void P3BillOfMaterialShouldBeCorrect()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var billOfMaterial = BillOfMaterialUtil.CreateBillOfMaterial(ds.GetItemById(3) as Product);

            // Product 3 must have 34 distinct items
            Assert.AreNotEqual(billOfMaterial.Count, 0);
            Assert.AreEqual(34, billOfMaterial.Count);

            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(6)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(9)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(12)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(15)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(16)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(17)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(20)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(26)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(29)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(30)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(31)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(23)]);
            Assert.AreEqual(7, billOfMaterial[ds.GetItemById(24)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(25)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(27)]);
            Assert.AreEqual(6, billOfMaterial[ds.GetItemById(28)]);
            Assert.AreEqual(3, billOfMaterial[ds.GetItemById(32)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(33)]);
            Assert.AreEqual(72, billOfMaterial[ds.GetItemById(34)]);
            Assert.AreEqual(4, billOfMaterial[ds.GetItemById(35)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(36)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(37)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(38)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(39)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(40)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(41)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(42)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(43)]);
            Assert.AreEqual(3, billOfMaterial[ds.GetItemById(44)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(45)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(46)]);
            Assert.AreEqual(1, billOfMaterial[ds.GetItemById(47)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(48)]);
            Assert.AreEqual(2, billOfMaterial[ds.GetItemById(59)]);
        }


        [TestCase]
        public void HasCorrectTotalStock()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var expectedTotalStockValue = 289555.0;

            var totalStock = 0.0;

            foreach (Item item in ds.GetAllItems())
            {
                totalStock += item.Stock * item.Value;
            }

            Assert.AreEqual(expectedTotalStockValue, totalStock);
        }

        [TestCase]
        public void HasCorrectOrderCostCheckSum()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var expectedOrderCostCheckSum = 1700.0;

            var orderCostCheckSum = 0.0;

            foreach (Item item in ds.GetAllItems())
            {
                if (item is ProcuredItem)
                {
                    orderCostCheckSum += (item as ProcuredItem).OrderCosts;
                }
            }

            Assert.AreEqual(expectedOrderCostCheckSum, orderCostCheckSum);
        }

        [TestCase]
        public void HasCorrectProcurementLeadTimeCheckSum()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var expectedProcurementLeadTimeCheckSum = 44.11;

            var procurementLeadTimeCheckSum = 0.0;

            foreach (Item item in ds.GetAllItems())
            {
                if (item is ProcuredItem)
                {
                    procurementLeadTimeCheckSum += (item as ProcuredItem).ProcureLeadTime;
                }
            }

            Assert.AreEqual(expectedProcurementLeadTimeCheckSum, procurementLeadTimeCheckSum);
        }

        [TestCase]
        public void UsedInWorksCorrectly()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();

            foreach (Item item in ds.GetAllItems())
            {
                if (item is FinishedProduct)
                {
                    Assert.AreEqual(0, item.UsedInProducts.Count);
                }
                if (item is UnfinishedProduct)
                {
                    Assert.AreNotEqual(0, item.UsedInProducts.Count);
                }
                if (item is ProcuredItem)
                {
                    Assert.AreNotEqual(0, item.UsedInProducts.Count);
                }
            }
        }

        [TestCase]
        public void WhereUsedListWorksWithItem32()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            var item = ds.GetItemById(32);

            var whereUsedList = BillOfMaterialUtil.CreateWhereUsedList(item);

            Assert.IsTrue(whereUsedList.Contains(ds.GetItemById(1) as Product));
            Assert.IsTrue(whereUsedList.Contains(ds.GetItemById(2) as Product));
            Assert.IsTrue(whereUsedList.Contains(ds.GetItemById(3) as Product));

            Assert.AreEqual(3, BillOfMaterialUtil.CreateBillOfMaterial(ds.GetItemById(1) as Product)[item]);
            Assert.AreEqual(3, BillOfMaterialUtil.CreateBillOfMaterial(ds.GetItemById(2) as Product)[item]);
            Assert.AreEqual(3, BillOfMaterialUtil.CreateBillOfMaterial(ds.GetItemById(3) as Product)[item]);
        }

        [TestCase]
        public void CreateBillOfMaterialTest()
        {
            var dataSource = new SQLiteDataSource();
            dataSource.Purge();
            var procuredItem = (ProcuredItem)dataSource.GetItemById(24);
            var p1 = dataSource.GetItemById(1) as FinishedProduct;
            var p2 = dataSource.GetItemById(2) as FinishedProduct;
            var p3 = dataSource.GetItemById(3) as FinishedProduct;

            var bom1 = BillOfMaterialUtil.CreateBillOfMaterial(p1);
            var bom2 = BillOfMaterialUtil.CreateBillOfMaterial(p2);
            var bom3 = BillOfMaterialUtil.CreateBillOfMaterial(p3);

            Assert.AreEqual(7, bom1[procuredItem]);
            Assert.AreEqual(7, bom2[procuredItem]);
            Assert.AreEqual(7, bom3[procuredItem]);
        }

        [TestCase]
        public void CreateWhereUsedListTest()
        {
            var dataSource = new SQLiteDataSource();
            dataSource.Purge();
            var procuredItem = (ProcuredItem)dataSource.GetItemById(24);

            var p1 = dataSource.GetItemById(1) as FinishedProduct;
            var p2 = dataSource.GetItemById(2) as FinishedProduct;
            var p3 = dataSource.GetItemById(3) as FinishedProduct;
            Console.WriteLine();
            Assert.AreEqual(1, (from q in procuredItem.UsageQuantities where q.Key.Id == 1 select q).Count());
            Assert.AreEqual(1, procuredItem.UsageQuantities[p1]);
            Assert.AreEqual(1, procuredItem.UsageQuantities[p2]);
            Assert.AreEqual(1, procuredItem.UsageQuantities[p3]);

            var whereUsedList = BillOfMaterialUtil.CreateWhereUsedList(procuredItem);

            Assert.AreEqual(13, whereUsedList.Count);
            Assert.AreEqual(7, (from product in whereUsedList where product == p1 select BillOfMaterialUtil.CreateBillOfMaterial(product)[procuredItem]).First());
            Assert.AreEqual(7, (from product in whereUsedList where product == p2 select BillOfMaterialUtil.CreateBillOfMaterial(product)[procuredItem]).First());
            Assert.AreEqual(7, (from product in whereUsedList where product == p3 select BillOfMaterialUtil.CreateBillOfMaterial(product)[procuredItem]).First());

        }

        [TestCase]
        public void HasCorrectNumberOfWorkplaces()
        {

            var ds = new SQLiteDataSource();
            ds.Purge();

            Assert.AreEqual(14, ds.GetAllWorkplaces().Count);
        }

        [TestCase]
        public void InsertAndReadItemWorks()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();

            var item = new FinishedProduct();
            item.Id = 999999;
            item.Description = "abc";
            item.Stock = 90;
            item.Value = 50.0;

            Item item2 = null;
            ds.AddNewItem(item);
            item2 = ds.GetItemById(999999);

            Assert.AreEqual(item.Id, item2.Id);
            Assert.AreEqual(item.Description, item2.Description);
            Assert.AreEqual(item.Stock, item2.Stock);
            Assert.AreEqual(item.Value, item2.Value);
        }

        [TestCase]
        public void InsertAndReadWorkplaceWorks()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();

            var workplace = new Workplace();
            workplace.Id = 999999;
            workplace.JobDescription = "Something";
            workplace.LaborCostsFirstShift = 10.0;
            workplace.LaborCostsSecondShift = 20.0;
            workplace.LaborCostsThirdShift = 30.0;
            workplace.LaborCostsOvertime = 40.0;
            workplace.IdleMachineCosts = 500.0;
            workplace.ProductiveMachineCosts = 50.0;

            Workplace workplace2 = null;
            ds.AddNewWorkplace(workplace);
            workplace2 = ds.GetWorkplaceById(999999);

            Assert.AreEqual(workplace.Id, workplace2.Id);
            Assert.AreEqual(workplace.JobDescription, workplace2.JobDescription);
            Assert.AreEqual(workplace.LaborCostsFirstShift, workplace2.LaborCostsFirstShift);
            Assert.AreEqual(workplace.LaborCostsSecondShift, workplace2.LaborCostsSecondShift);
            Assert.AreEqual(workplace.LaborCostsThirdShift, workplace2.LaborCostsThirdShift);
            Assert.AreEqual(workplace.LaborCostsOvertime, workplace2.LaborCostsOvertime);
            Assert.AreEqual(workplace.IdleMachineCosts, workplace2.IdleMachineCosts);
            Assert.AreEqual(workplace.ProductiveMachineCosts, workplace2.ProductiveMachineCosts);
        }

        [TestCase]
        public void InsertAndReadItemJobWorks()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();
            
            var item = new FinishedProduct();
            item.Id = 999999;
            item.Description = "abc";
            item.Stock = 90;
            item.Value = 50.0;
            ds.AddNewItem(item);

            
            var workplace = new Workplace();
            workplace.Id = 999999;
            workplace.JobDescription = "Something";
            workplace.LaborCostsFirstShift = 10.0;
            workplace.LaborCostsSecondShift = 20.0;
            workplace.LaborCostsThirdShift = 30.0;
            workplace.LaborCostsOvertime = 40.0;
            workplace.IdleMachineCosts = 500.0;
            workplace.ProductiveMachineCosts = 50.0;

            ds.AddNewWorkplace(workplace);

            var itemJob = new ItemJob();
            itemJob.Id = 999999;
            itemJob.Product = item;
            itemJob.ProductionTimePerPiece = 50.0;
            itemJob.SetupTime = 100.0;
            itemJob.Workplace = workplace;

            ItemJob itemJob2 = null;
            ds.AddNewItemJob(itemJob);
            itemJob2 = ds.GetItemJobById(itemJob.Id);


            Assert.AreEqual(itemJob.Id, itemJob2.Id);
            Assert.NotNull(itemJob.Product);
            Assert.AreEqual(itemJob.Product.Id, itemJob2.Product.Id);
            Assert.AreEqual(itemJob.ProductionTimePerPiece, itemJob2.ProductionTimePerPiece);
            Assert.AreEqual(itemJob.SetupTime, itemJob2.SetupTime);
            Assert.NotNull(itemJob.Workplace);
            Assert.AreEqual(itemJob.Workplace.Id, itemJob2.Workplace.Id);
            Assert.AreEqual(1, itemJob2.Workplace.Jobs.Count);
        }

        [TestCase]
        public void AddChildToProductShouldWork()
        {
            var ds = new SQLiteDataSource();
            ds.Purge();

            var a = new FinishedProduct();
            a.Id = 100001;
            a.Description = "a";
            a.Stock = 90;
            a.Value = 50.0;
            ds.AddNewItem(a);

            var b = new UnfinishedProduct();
            b.Id = 100002;
            b.Description = "b";
            b.Stock = 90;
            b.Value = 50.0;
            ds.AddNewItem(b);


            var c = new ProcuredItem();
            c.Id = 100003;
            c.Description = "c";
            c.Stock = 90;
            c.Value = 50.0;
            ds.AddNewItem(c);

            ds.AddChildToProduct(b, c, 5);
            ds.AddChildToProduct(a, b, 2);

            var a2 = (Product) ds.GetItemById(a.Id);
            var b2 = ds.GetItemById(b.Id);
            var c2 = ds.GetItemById(c.Id);

            Assert.IsNotNull(a2);
            Assert.IsNotNull(b2);
            Assert.IsNotNull(c2);


            Assert.AreEqual(1, a2.ItemQuantities.Count);
            Assert.AreEqual(1, b2.UsedInProducts.Count);
            Assert.AreEqual(1, c2.UsedInProducts.Count);

        }

        [TestCase]
        public void GetItemByIdShouldWork() {
            var ds = new SQLiteDataSource();
            ds.Purge();

            var product1 = (Product)ds.GetItemById(1);

            Assert.AreNotEqual(0, product1.ItemQuantities);

        }
    }
}
