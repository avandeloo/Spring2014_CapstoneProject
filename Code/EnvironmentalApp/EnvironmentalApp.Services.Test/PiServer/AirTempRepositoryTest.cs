using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core.PiServerTableTags;
namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class AirTempRepositoryTest
    {
        [TestMethod]
        public void AirTemp_CanGetToday()
        {
            var airTempRepo = new Data.PiServer.AirTemp_PI_Repository();
            var result = airTempRepo.GetToday(AirTempSource.OutsideTemp);

            Assert.IsNotNull(result,"Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.AirTemp), "Not an instance of Air temp");
            
        }
        [TestMethod]
        public void AirTemp_CanGetByTime()
        {
            var airTempRepo = new Data.PiServer.AirTemp_PI_Repository();
            var result = airTempRepo.GetByTime(AirTempSource.OutsideTemp,"yesterday");

            Assert.IsNotNull(result, "Object is null");
          
        }
        [TestMethod]
        public void AirTemp_CanGetTimeRange()
        {
            var airTempRepo = new Data.PiServer.AirTemp_PI_Repository();
            var result = airTempRepo.GetByTime(AirTempSource.OutsideTemp,"-2d","today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.AirTemp), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
