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
    public class ETLSolarTest
    {

        [TestMethod]
        public void SolarCarChargerCanFetchAndDumpData()
        {
            var solarCarCharger = new ETL_SolarService();
            var result = solarCarCharger.SolarCarCharger_Fetch_And_Dump_Data_ByDateRange(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

        [TestMethod]
        public void SolarBusBarnCanFetchAndDumpData()
        {
            var solarBusBarn = new ETL_SolarService();
            var result = solarBusBarn.SolarBusBarn_Fetch_And_Dump_Data_ByDateRange(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

    }
}
