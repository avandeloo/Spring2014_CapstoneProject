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
            var solarRepo = new Data.PiServer.Solar_BusBarn_PI_Repository();
            var result = solarRepo.GetToday(SolarSources.BusBarn);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_BusBarn), "Not an instance of Solar Bus Barn");

        }
        [TestMethod]
        public void Solar_BusBarn_CanGetByTime()
        {
            var solarRepo = new Data.PiServer.Solar_BusBarn_PI_Repository();
            var result = solarRepo.GetByTime(SolarSources.BusBarn,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Solar_BusBarn_CanGetByTimeRange()
        {
            var solarRepo = new Data.PiServer.Solar_BusBarn_PI_Repository();
            var result = solarRepo.GetByTime(SolarSources.BusBarn,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar_BusBarn), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
        [TestMethod]
        public void Solar_CarCharging_CanGetToday()
        {
            var solarRepo = new Data.PiServer.Solar_CarCharger_PI_Repository();
            var result = solarRepo.GetToday(SolarSources.CarPort);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_CarCharger), "Not an instance of Solar Car Charging");

        }
        [TestMethod]
        public void Solar_CarCharging_CanGetByTime()
        {
            var solarRepo = new Data.PiServer.Solar_CarCharger_PI_Repository();
            var result = solarRepo.GetByTime(SolarSources.CarPort,"yesterday");

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_CarCharger), "Not an instance of Solar Car Charging");

        }
        [TestMethod]
        public void Solar_CarCharging_CanGetByTimeRange()
        {
            var solarRepo = new Data.PiServer.Solar_CarCharger_PI_Repository();
            var result = solarRepo.GetByTime(SolarSources.CarPort,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar_CarCharger), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
