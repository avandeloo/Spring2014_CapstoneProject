using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Data.PiServer;

namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class ChilledWaterRespositoryTest
    {
        [TestMethod]
        public void CanGetTodayChilledWater()
        {
            var chilledWaterRepo = new ChilledWaterRepository();
            var chilledWaterList = chilledWaterRepo.GetToday();

            Assert.IsNotNull(chilledWaterList);
        }
        [TestMethod]
        public void CanGetChilledWaterByTime()
        {
            var chilledWaterRepo = new ChilledWaterRepository();
            var chilledWaterList = chilledWaterRepo.GetByTime("yesterday");

            Assert.IsNotNull(chilledWaterList);
            Assert.IsTrue(chilledWaterList.Count >= 1, "No records in chilled water list");
        }
        [TestMethod]
        public void CanGetChilledWaterByTimeRange()
        {
            var chilledWaterRepo = new ChilledWaterRepository();
            var chilledWaterList = chilledWaterRepo.GetByTime("yesterday","today");

            Assert.IsNotNull(chilledWaterList);
            Assert.IsTrue(chilledWaterList.Count >= 1, "No records in chilled water list");
        }
        [TestMethod]
        public void CanGetTodayTotalChilledWater()
        {
            var chilledWaterRepo = new ChilledWaterRepository();
            var chilledWaterList = chilledWaterRepo.CampusTotalToday();

            Assert.IsNotNull(chilledWaterList);

        }
        [TestMethod]
        public void CanGetTotalChilledWaterByTime()
        {
            var chilledWaterRepo = new ChilledWaterRepository();
            var chilledWaterList = chilledWaterRepo.CapmusTotalByDate("yesterday");

            Assert.IsNotNull(chilledWaterList);
            Assert.IsTrue(chilledWaterList.Count >= 1, "No records in chilled water list");
        }
        [TestMethod]
        public void CanGetTotalChilledWaterByTimeRange()
        {
            var chilledWaterRepo = new ChilledWaterRepository();
            var chilledWaterList = chilledWaterRepo.CapmusTotalByDate("yesterday","today");

            Assert.IsNotNull(chilledWaterList);
            Assert.IsTrue(chilledWaterList.Count >= 1, "No records in chilled water list");
        }
    }
}
