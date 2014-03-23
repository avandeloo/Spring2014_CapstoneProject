using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Data.Tests.PiServer
{
    [TestClass]
    public class SteamRepositoryTest
    {
        [TestMethod]
        public void Steam_PBB_CanGetToday()
        {
            var steamRepo = new Data.PiServer.SteamRepository();
            var result = steamRepo.GetToday(SteamSources.PBB_Steam);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Steam), "Not an instance of Steam");

        }
        [TestMethod]
        public void Steam_PBB_CanGetByTime()
        {
            var steamRepo = new Data.PiServer.SteamRepository();
            var result = steamRepo.GetByTime(SteamSources.PBB_Steam,"yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Steam_PBB_CanGetByTimeRange()
        {
            var steamRepo = new Data.PiServer.SteamRepository();
            var result = steamRepo.GetByTime(SteamSources.PBB_Steam,"-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Steam), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
        [TestMethod]
        public void Steam_CampusTotal_CanGetToday()
        {
            var steamRepo = new Data.PiServer.SteamRepository();
            var result = steamRepo.GetToday(SteamSources.Campus_Total);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Steam), "Not an instance of Steam");

        }
        [TestMethod]
        public void Steam_CampusTotal_CanGetByTime()
        {
            var steamRepo = new Data.PiServer.SteamRepository();
            var result = steamRepo.GetByTime(SteamSources.Campus_Total, "yesterday");

            Assert.IsNotNull(result, "Object is null");

        }
        [TestMethod]
        public void Steam_CampusTotal_CanGetByTimeRange()
        {
            var steamRepo = new Data.PiServer.SteamRepository();
            var result = steamRepo.GetByTime(SteamSources.Campus_Total, "-2d", "today");

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Steam), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
    }
}
