using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Data.PiServer;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class ChilledWaterRespositoryTest
    {
        [TestMethod]
        public void ChilledWater_PBB_CanGetToday()
        {
            var chilledWaterRepo = new ChilledWater_PI_Repository();
            var chilledWaterList = chilledWaterRepo.GetToday(ChilledWaterSources.PBB_ChilledWater);

            Assert.IsNotNull(chilledWaterList);
        }
        [TestMethod]
        public void ChilledWater_PBB_CanGetWaterByTime()
        {
            var chilledWaterRepo = new ChilledWater_PI_Repository();
            var chilledWaterList = chilledWaterRepo.GetByTime(ChilledWaterSources.PBB_ChilledWater,"yesterday");

            Assert.IsNotNull(chilledWaterList);
           
        }
        [TestMethod]
        public void ChilledWater_PBB_CanGetByTimeRange()
        {
            var chilledWaterRepo = new ChilledWater_PI_Repository();
            var chilledWaterList = chilledWaterRepo.GetByTime(ChilledWaterSources.PBB_ChilledWater,"yesterday","today");

            Assert.IsNotNull(chilledWaterList);
            Assert.IsTrue(chilledWaterList.Count >= 1, "No records in chilled water list");
        }
        [TestMethod]
        public void ChilledWater_CampusTotal_CanGetToday()
        {
            var chilledWaterRepo = new ChilledWater_PI_Repository();
            var chilledWaterList = chilledWaterRepo.GetToday(ChilledWaterSources.Campus_Total);

            Assert.IsNotNull(chilledWaterList);

        }
        [TestMethod]
        public void ChilledWater_CampusTotal_CanGetlByTime()
        {
            var chilledWaterRepo = new ChilledWater_PI_Repository();
            var chilledWaterList = chilledWaterRepo.GetByTime(ChilledWaterSources.Campus_Total,"yesterday");

            Assert.IsNotNull(chilledWaterList);
          
        }
        [TestMethod]
        public void ChilledWater_CampusTotal_CanGetByTimeRange()
        {
            var chilledWaterRepo = new ChilledWater_PI_Repository();
            var chilledWaterList = chilledWaterRepo.GetByTime(ChilledWaterSources.Campus_Total,"yesterday","today");

            Assert.IsNotNull(chilledWaterList);
            Assert.IsTrue(chilledWaterList.Count >= 1, "No records in chilled water list");
        }
    }
}
