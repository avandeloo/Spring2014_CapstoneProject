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
    public class SqlSolarBusBarnRepositoryTest
    {

            private List<Solar_BusBarn> solarBusBarnList = null;
            [TestInitialize]
            public void Setup()
            {
                solarBusBarnList = new List<Solar_BusBarn> 
                { 
                    new Solar_BusBarn { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_BusBarn { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_BusBarn { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void Solar_Bus_Barn_Records_Match()
            {
                var solarBusBarnRepo = new Solar_BusBarn_SQL_Repository();
                Assert.AreEqual(3, solarBusBarnList.Count);

                var result = solarBusBarnRepo.Create(solarBusBarnList);
                Assert.AreEqual(solarBusBarnList.Count, result);
            }


            [TestMethod]
            public void Solar_Bus_Barn_CanGetToday()
            {
                var solarBusBarnRepo = new Solar_BusBarn_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var result = solarBusBarnRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_BusBarn), "Not an instance of Solar Bus Barn");

            }
            [TestMethod]
            public void Solar_Bus_Barn_CanGetByTime()
            {
                var solarBusBarnRepo = new Solar_BusBarn_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var result = solarBusBarnRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void Solar_Bus_Barn_CanGetTimeRange()
            {
                var solarBusBarnRepo = new Solar_BusBarn_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-10 22:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-12 22:00:00.000");

                var result = solarBusBarnRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar_BusBarn), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
