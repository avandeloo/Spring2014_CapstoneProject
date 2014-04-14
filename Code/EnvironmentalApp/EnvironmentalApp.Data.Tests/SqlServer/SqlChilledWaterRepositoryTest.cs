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
    public class SqlChilledWaterRepositoryTest
    {

            private List<ChilledWater> chilledWaterList = null;
            [TestInitialize]
            public void Setup()
            {
                chilledWaterList = new List<ChilledWater> 
                { 
                    new ChilledWater { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void PBB_CHILLED_WATER_Records_Match()
            {
                var PBBChilledWaterRepo = new ChilledWater_SQL_Repository();
                Assert.AreEqual(3, chilledWaterList.Count);

                var result = PBBChilledWaterRepo.Create(chilledWaterList);
                Assert.AreEqual(chilledWaterList.Count, result);
            }


            [TestMethod]
            public void PBB_CHILLED_WATER_CanGetToday()
            {
                var PBBChilledWaterRepo = new ChilledWater_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-09 23:00:00.000");
                var result = PBBChilledWaterRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.ChilledWater), "Not an instance of PBB Chilled Water");

            }
            [TestMethod]
            public void PBB_CHILLED_WATER_CanGetByTime()
            {
                var PBBChilledWaterRepo = new ChilledWater_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-10 00:00:00.000");
                var result = PBBChilledWaterRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void PBB_CHILLED_WATER_CanGetTimeRange()
            {
                var PBBChilledWaterRepo = new ChilledWater_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-09 23:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-10 00:00:00.000");

                var result = PBBChilledWaterRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.ChilledWater), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
