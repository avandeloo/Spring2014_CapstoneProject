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
    public class SqlAirTempRepositoryTest
    {

            private List<AirTemp> airTempList = null;
            [TestInitialize]
            public void Setup()
            {
                airTempList = new List<AirTemp> 
                { 
                    new AirTemp { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new AirTemp { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new AirTemp { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }
        
            [TestMethod]
            public void Air_Temp_Records_Match()
            {
                var airTempRepo = new AirTemp_SQL_Repository();
                Assert.AreEqual(3, airTempList.Count);

                var result = airTempRepo.Create(airTempList);
                Assert.AreEqual(airTempList.Count, result);
            }


            [TestMethod]
            public void Air_Temp_CanGetToday()
            {
                var airTempRepo = new AirTemp_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
                var result = airTempRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.AirTemp), "Not an instance of Air Temp");

            }
            [TestMethod]
            public void Air_Temp_CanGetByTime()
            {
                var airTempRepo = new AirTemp_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
                var result = airTempRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void Air_Temp_CanGetTimeRange()
            {
                var airTempRepo = new AirTemp_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-10 23:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-12 23:00:00.000");

                var result = airTempRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.AirTemp), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
