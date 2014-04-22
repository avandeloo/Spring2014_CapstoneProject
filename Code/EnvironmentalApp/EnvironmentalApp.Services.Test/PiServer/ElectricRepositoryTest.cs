using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class ElectricRepositoryTest
    {
        [TestMethod]
        public void Electric_PBB_CanGetToday()
        {
            var eRepo = new Data.PiServer.Electric_PI_Repository();
            var result = eRepo.GetToday(ElectricSources.PBB_Electric);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Electric), "Not an instance of Electric");

        }
        [TestMethod]
        public void Electric_PBB_CanGetByTime()
        {
            var eRepo = new Data.PiServer.Electric_PI_Repository();
            var result = eRepo.GetByTime(ElectricSources.PBB_Electric,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Electric_PBB_CanGetByTimeRange()
        {
            var eRepo = new Data.PiServer.Electric_PI_Repository();
            var result = eRepo.GetByTime(ElectricSources.PBB_Electric,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Electric), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
        [TestMethod]
        public void Electric_CampustTotal_CanGetToday()
        {
            var eRepo = new Data.PiServer.Electric_PI_Repository();
            var result = eRepo.GetToday(ElectricSources.Campus_Total);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Electric), "Not an instance of Electric");

        }
        [TestMethod]
        public void Electric_CampustTotal_CanGetByTime()
        {
            var eRepo = new Data.PiServer.Electric_PI_Repository();
            var result = eRepo.GetByTime(ElectricSources.Campus_Total, "yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Electric_CampustTotal_CanGetByTimeRange()
        {
            var eRepo = new Data.PiServer.Electric_PI_Repository();
            var result = eRepo.GetByTime(ElectricSources.Campus_Total, "-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Electric), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
