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
    public class SqlSolarRadiationRepositoryTest
    {

            private List<SolarRadiation> solarRadiationList = null;
            [TestInitialize]
            public void Setup()
            {
                solarRadiationList = new List<SolarRadiation> 
                { 
                    new SolarRadiation { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new SolarRadiation { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new SolarRadiation { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void SolarRadiation_Records_Match()
            {
                var solarRadiationRepo = new SolarRadiation_SQL_Repository();
                Assert.AreEqual(3, solarRadiationList.Count);

                var result = solarRadiationRepo.Create(solarRadiationList);
                Assert.AreEqual(solarRadiationList.Count, result);
            }


            [TestMethod]
            public void SolarRadiation_CanGetToday()
            {
                var solarRadiationRepo = new SolarRadiation_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-13 23:00:00.000");
                var result = solarRadiationRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.SolarRadiation), "Not an instance of PBB Chilled Water");

            }
            [TestMethod]
            public void SolarRadiation_CanGetByTime()
            {
                var solarRadiationRepo = new SolarRadiation_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-14 00:00:00.000");
                var result = solarRadiationRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void SolarRadiation_CanGetTimeRange()
            {
                var solarRadiationRepo = new SolarRadiation_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-13 22:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-14 00:00:00.000");

                var result = solarRadiationRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SolarRadiation), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
