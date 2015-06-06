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
    public class ModelTest
    {

        [TestCase]
        public void AddItemToProductTest()
        {
            Product p = new UnfinishedProduct { Id = 1 };
            ProcuredItem i1 = new ProcuredItem { Id = 2 };
            ProcuredItem i2 = new ProcuredItem { Id = 3 };

            p.AddItem(i1, 5);
            p.AddItem(i2, 6);
            p.AddItem(i2, 6);

            Assert.AreEqual(2, p.ItemQuantities.Count);
            Assert.AreEqual(5, p.ItemQuantities[i1]);
            Assert.AreEqual(12, p.ItemQuantities[i2]);

            Assert.AreEqual(1, i1.UsageQuantities.Count);
            Assert.AreEqual(5, i1.UsageQuantities[p]);

            Assert.AreEqual(1, i2.UsageQuantities.Count);
            Assert.AreEqual(12, i2.UsageQuantities[p]);

        }
    }
}
