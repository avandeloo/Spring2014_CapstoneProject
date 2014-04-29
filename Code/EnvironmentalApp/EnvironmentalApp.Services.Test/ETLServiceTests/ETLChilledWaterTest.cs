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
    public class ETLChilledWaterTest
    {

        [TestMethod]
        public void ChilledWaterCanFetchAndDumpData()
        {
            var chilledWater = new ETL_ChilledWaterService();
            var result = chilledWater.TransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

        [TestMethod]
        public void ChilledWaterCampusCanFetchAndDumpData()
        {
            var chilledWaterCampus = new ETL_ChilledWaterService();
            var result = chilledWaterCampus.CampusTransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

    }
}
