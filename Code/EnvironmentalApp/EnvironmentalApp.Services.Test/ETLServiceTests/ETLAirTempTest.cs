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
    public class ETLAirTempTest
    {

        [TestMethod]
        public void AirTempCanFetchAndDumpData()
        {
            var airTemp = new ETL_AirTempService();
            var result = airTemp.TransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-9), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

    }
}
