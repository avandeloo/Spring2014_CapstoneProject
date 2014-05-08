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
    public class ETLSteamTest
    {

        [TestMethod]
        public void SteamCanFetchAndDumpData()
        {
            var steam = new ETL_SteamService();
            var result = steam.TransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-9), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }

        [TestMethod]
        public void SteamCampusCanFetchAndDumpData()
        {
            var steamCampus = new ETL_SteamService();
            var result = steamCampus.CampusTransferPiHourlyToSqlHourly(DateTime.Now.AddDays(-1), DateTime.Now);

            Assert.IsNotNull(result);
            Assert.IsTrue(result > 23);
        }


    }
}
