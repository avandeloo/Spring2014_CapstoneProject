using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class HumidityRepositoryTest
    {
        [TestMethod]
        public void Humidity_CanGetToday()
        {
            var humidityRepo = new Data.PiServer.HumidityRepository();
            var result = humidityRepo.GetToday(HumiditySources.Campus_Total);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Humidity), "Not an instance of Humidity");

        }
        [TestMethod]
        public void Humidity_CanGetByTime()
        {
            var humidityRepo = new Data.PiServer.HumidityRepository();
            var result = humidityRepo.GetByTime(HumiditySources.Campus_Total,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Humidity_CanGetByTimeRange()
        {
            var humidityRepo = new Data.PiServer.HumidityRepository();
            var result = humidityRepo.GetByTime(HumiditySources.Campus_Total,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Humidity), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
