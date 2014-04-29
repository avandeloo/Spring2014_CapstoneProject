using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Services.ETLServices;

namespace EnvironmentalApp.Services.Tests.ETLServiceTests
{
    [TestClass]
    public class ETLElectricTest
    {

        [TestMethod]
        public void ElectricCanFetchAndDumpData()
        {
            var electric = new ETL_ElectricService();
            var result = electric.TransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

        [TestMethod]
        public void ElectricCampusCanFetchAndDumpData()
        {
            var electricCampus = new ETL_ElectricService();
            var result = electricCampus.CampusTransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

    }
}
