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
    public class SqlTotalCampusSteamRepositoryTest
    {

        private List<Steam_Campus> totalCampusSteamList = null;
            [TestInitialize]
            public void Setup()
            {
                totalCampusSteamList = new List<Steam_Campus> 
                { 
                    new Steam_Campus { Id = Guid.NewGuid(), Reading = 30.9f, ReadingDateTime = DateTime.Now, Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 }, 
                    new Steam_Campus { Id = Guid.NewGuid(), Reading = 32.9f, ReadingDateTime = DateTime.Now.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 },
                    new Steam_Campus { Id = Guid.NewGuid(), Reading = 34.9f, ReadingDateTime = DateTime.Now.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 }
                };
            }

            [TestMethod]
            public void TotalCampus_STEAM_Records_Match()
            {
                var totalCampusSteamRepo = new Steam_Campus_SQL_Repository();
                Assert.AreEqual(3, totalCampusSteamList.Count);
                
                var result = totalCampusSteamRepo.Create(totalCampusSteamList);
                Assert.AreEqual(totalCampusSteamList.Count, result);
            }


            [TestMethod]
            public void TotalCampus_STEAM_CanGetToday()
            {
                var totalCampusSteamRepo = new Steam_Campus_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-11 23:15:03.653");
                var result = totalCampusSteamRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Steam_Campus), "Not an instance of Total Campus Steam");

            }
            [TestMethod]
            public void TotalCampus_STEAM_CanGetByTime()
            {
                var totalCampusSteamRepo = new Steam_Campus_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-10 23:15:03.667");
                var result = totalCampusSteamRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void TotalCampus_STEAM_CanGetTimeRange()
            {
                var totalCampusSteamRepo = new Steam_Campus_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-10 22:15:03.667");
                var endTime = Convert.ToDateTime("2014-04-11 23:15:03.653");

                var result = totalCampusSteamRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Steam_Campus), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
