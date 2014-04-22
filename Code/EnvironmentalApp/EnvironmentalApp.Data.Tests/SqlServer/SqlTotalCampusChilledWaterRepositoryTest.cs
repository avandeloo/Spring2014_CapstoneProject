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
    public class SqlTotalCampusChilledWaterRepositoryTest
    {

            private List<ChilledWater_Campus> totalCampusChilledWaterList = null;
            [TestInitialize]
            public void Setup()
            {
                totalCampusChilledWaterList = new List<ChilledWater_Campus> 
                { 
                    new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void Total_Campus_CHILLED_WATER_Records_Match()
            {
                var totalCampusChilledWaterRepo = new ChilledWater_Campus_SQL_Repository();
                Assert.AreEqual(3, totalCampusChilledWaterList.Count);

                var result = totalCampusChilledWaterRepo.Create(totalCampusChilledWaterList);
                Assert.AreEqual(totalCampusChilledWaterList.Count, result);
            }


            [TestMethod]
            public void Total_Campus_CHILLED_WATER_CanGetToday()
            {
                var totalCampusChilledWaterRepo = new ChilledWater_Campus_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
                var result = totalCampusChilledWaterRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.ChilledWater_Campus), "Not an instance of Total Campus Chilled Water");

            }
            [TestMethod]
            public void Total_Campus_CHILLED_WATER_CanGetByTime()
            {
                var totalCampusChilledWaterRepo = new ChilledWater_Campus_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
                var result = totalCampusChilledWaterRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void Total_Campus_CHILLED_WATER_CanGetTimeRange()
            {
                var totalCampusChilledWaterRepo = new ChilledWater_Campus_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-10 23:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-12 23:00:00.000");

                var result = totalCampusChilledWaterRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.ChilledWater_Campus), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
