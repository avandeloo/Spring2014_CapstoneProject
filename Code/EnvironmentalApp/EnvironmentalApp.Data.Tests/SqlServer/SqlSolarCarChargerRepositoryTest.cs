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
    public class SqlSolarCarChargerRepositoryTest
    {

            private List<Solar_CarCharger> solarCarChargerList = null;
            [TestInitialize]
            public void Setup()
            {
                solarCarChargerList = new List<Solar_CarCharger> 
                { 
                    new Solar_CarCharger { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_CarCharger { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_CarCharger { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void Solar_Car_Charger_Records_Match()
            {
                var solarCarChargerRepo = new Solar_CarCharger_SQL_Repository();
                Assert.AreEqual(3, solarCarChargerList.Count);

                var result = solarCarChargerRepo.Create(solarCarChargerList);
                Assert.AreEqual(solarCarChargerList.Count, result);
            }


            [TestMethod]
            public void Solar_Car_Charger_CanGetToday()
            {
                var solarCarChargerRepo = new Solar_CarCharger_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var result = solarCarChargerRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_CarCharger), "Not an instance of PBB Chilled Water");

            }
            [TestMethod]
            public void Solar_Car_Charger_CanGetByTime()
            {
                var solarCarChargerRepo = new Solar_CarCharger_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var result = solarCarChargerRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void Solar_Car_Charger_CanGetTimeRange()
            {
                var solarCarChargerRepo = new Solar_CarCharger_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-10 22:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-12 22:00:00.000");

                var result = solarCarChargerRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar_CarCharger), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
