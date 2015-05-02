using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SupplyChainManagement;

namespace SupplyChainManagementTest
{
    [TestClass]
    public class CalculationModelTest
    {

        [TestMethod]
        public void NewModelReturnsNotNull() {
            Assert.IsNotNull(Calculation.NewCalculation(new DataSourceMock()));
        }


        [TestMethod]
        public void TraversingWorks()
        {

        }


    }
}
