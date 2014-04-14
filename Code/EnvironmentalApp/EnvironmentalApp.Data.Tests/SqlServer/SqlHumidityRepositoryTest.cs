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
    public class SqlHumidityRepositoryTest
    {

            private List<Humidity> humidityList = null;
            [TestInitialize]
            public void Setup()
            {
                humidityList = new List<Humidity> 
                { 
                    new Humidity { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Humidity { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Humidity { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void Humidity_Records_Match()
            {
                var humidityRepo = new Humidity_SQL_Repository();
                Assert.AreEqual(3, humidityList.Count);

                var result = humidityRepo.Create(humidityList);
                Assert.AreEqual(humidityList.Count, result);
            }


            [TestMethod]
            public void Humidity_CanGetToday()
            {
                var humidityRepo = new Humidity_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-13 00:00:00.000");
                var result = humidityRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Humidity), "Not an instance of Humidity");

            }
            [TestMethod]
            public void Humidity_CanGetByTime()
            {
                var humidityRepo = new Humidity_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-13 00:00:00.000");
                var result = humidityRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void Humidity_CanGetTimeRange()
            {
                var humidityRepo = new Humidity_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-11 00:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-13 00:00:00.000");

                var result = humidityRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Humidity), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
