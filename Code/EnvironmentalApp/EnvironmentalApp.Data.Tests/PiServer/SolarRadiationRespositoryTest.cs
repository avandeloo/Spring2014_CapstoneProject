using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class SolarRadiationRespositoryTest
    {
        [TestMethod]
        public void SolarRadiation_CampusTotal_CanGetToday()
        {
            var solarRRepo = new Data.PiServer.SolarRadiationRepository();
            var result = solarRRepo.GetToday(SolarRadiationSources.Campus_Total);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SolarRadiation), "Not an instance of SolarRadiation");

        }
        [TestMethod]
        public void SolarRadiation_CampusTotal_CanGetByTime()
        {
            var solarRRepo = new Data.PiServer.SolarRadiationRepository();
            var result = solarRRepo.GetByTime(SolarRadiationSources.Campus_Total,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void SolarRadiation_CampusTotal_CanGetByTimeRange()
        {
            var solarRRepo = new Data.PiServer.SolarRadiationRepository();
            var result = solarRRepo.GetByTime(SolarRadiationSources.Campus_Total,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SolarRadiation), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
