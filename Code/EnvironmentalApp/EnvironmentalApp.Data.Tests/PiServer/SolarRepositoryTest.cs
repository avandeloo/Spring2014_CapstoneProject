using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  EnvironmentalApp.Core.PiServerTableTags;
namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class SolarRepositoryTest
    {
        

        [TestMethod]
        public void Solar_BusBarn_CanGetToday()
        {
            var solarRepo = new Data.PiServer.SolarRepository();
            var result = solarRepo.GetToday(SolarSource.BusBarn);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar), "Not an instance of Air temp");

        }
        [TestMethod]
        public void Solar_BusBarn_CanGetByTime()
        {
            var solarRepo = new Data.PiServer.SolarRepository();
            var result = solarRepo.GetByTime(SolarSource.BusBarn,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Solar_BusBarn_CanGetByTimeRange()
        {
            var solarRepo = new Data.PiServer.SolarRepository();
            var result = solarRepo.GetByTime(SolarSource.BusBarn,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
        [TestMethod]
        public void Solar_CarCharging_CanGetToday()
        {
            var solarRepo = new Data.PiServer.SolarRepository();
            var result = solarRepo.GetToday(SolarSource.CarPort);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar), "Not an instance of Air temp");

        }
        [TestMethod]
        public void Solar_CarCharging_CanGetByTime()
        {
            var solarRepo = new Data.PiServer.SolarRepository();
            var result = solarRepo.GetByTime(SolarSource.CarPort,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Solar_CarCharging_CanGetByTimeRange()
        {
            var solarRepo = new Data.PiServer.SolarRepository();
            var result = solarRepo.GetByTime(SolarSource.CarPort,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
