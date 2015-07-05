using System;

using NUnit.Framework;

using System.IO;
using System.Collections.Generic;

using System.Linq;

using SupplyChainManagement;
using SupplyChainManagement.Data;
using SupplyChainManagement.Models;
using SupplyChainManagement.Models.ItemManagement;
using SupplyChainManagement.Services;
using SupplyChainManagement.Util;


namespace SupplyChainManagementTest
{
    public class SimulatorClientTest
    {

        private string _TestUsername;
        private string _TestPassword;

        public SimulatorClientTest() {
            _TestUsername = Environment.GetEnvironmentVariable("SCM_TEST_USERNAME");
            _TestPassword = Environment.GetEnvironmentVariable("SCM_TEST_PASSWORD");

            Assert.IsNotNullOrEmpty(_TestUsername, "Please set SCM_TEST_USERNAME env variable");
            Assert.IsNotNullOrEmpty(_TestPassword, "Please set SCM_TEST_PASSWORD env variable");
        }

        [TestCase]
        public void LoginShouldWork() {

            var uri = new Uri("http://scsim-phoenix.de:8080");
            var c = new SimulatorClient(uri);

            try
            {
                c.Login("wronguser", "wrongpassword");
                Assert.Fail("Exception wasn't thrown");
            }
            catch (SimulatorException) {
            }


            c.Login(_TestUsername, _TestPassword);
        }


        [TestCase]
        public void ShouldReadResult() 
        {
            var uri = new Uri("http://scsim-phoenix.de:8080");
            var c = new SimulatorClient(uri);
            c.Login(_TestUsername, _TestPassword);

            var content = c.ReadResult(new Uri("http://scsim-phoenix.de:8080/scs/data/output/169_2_8result.xml"));

            Assert.IsNotNull(content);
            Assert.IsNotEmpty(content);
        }

        //[TestCase]
        public void ShouldWriteInputData()
        {
            var uri = new Uri("http://scsim-phoenix.de:8080");
            var c = new SimulatorClient(uri);
            c.Login(_TestUsername, _TestPassword);

            var data = "";
            using (StreamReader sr = new StreamReader("..\\..\\Fixtures\\TestInput_Period1.xml"))
            {
                data = sr.ReadToEnd();
            }

            c.WriteInputData(data);
        }

    }
}
