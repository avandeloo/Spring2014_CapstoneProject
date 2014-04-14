using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer.Repositories;
using System.Collections.Generic;


namespace EnvironmentalApp.Data.Tests.SqlServer
{
    [TestClass]
    public class SqlSteamRepositoryTest
    {
       
            private List<Steam> steamList = null;
            [TestInitialize]
            public void Setup()
            {
                steamList = new List<Steam> 
                { 
                    new Steam { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void PBB_STEAM_Records_Match()
            {
                var PBBSteamRepo = new Steam_SQL_Repository();
                Assert.AreEqual(3, steamList.Count);

                var result = PBBSteamRepo.Create(steamList);
                Assert.AreEqual(steamList.Count, result);
            }


            [TestMethod]
            public void PBB_STEAM_CanGetToday()
            {
                var PBBSteamRepo = new Steam_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-10 00:00:00.000");
                var result = PBBSteamRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Steam), "Not an instance of PBB Steam");

            }
            [TestMethod]
            public void PBB_STEAM_CanGetByTime()
            {
                var PBBSteamRepo = new Steam_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-09 23:00:00.000");
                var result = PBBSteamRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void PBB_STEAM_CanGetTimeRange()
            {
                var PBBSteamRepo = new Steam_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-09 22:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-09 23:00:00.000");
                
                var result = PBBSteamRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Steam), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
