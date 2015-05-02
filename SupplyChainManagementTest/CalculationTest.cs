using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using SupplyChainManagement;

namespace SupplyChainManagementTest
{
    public class CalculationTest
    {

        [TestCase]
        public void NewCalcluationReturnsNotNull() {
            Assert.IsNotNull(Calculation.NewCalculation(new DataSourceMock()));
        }

        [TestCase]
        public void TraversingWorks()
        {

        }


    }
}
