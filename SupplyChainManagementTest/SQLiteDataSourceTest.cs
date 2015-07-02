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
    public class SQLiteDataSourceTest
    {

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
        }
    }
}
