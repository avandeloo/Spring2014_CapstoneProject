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
    public class SqlTotalCampusElectricRepositoryTest
    {

            private List<Electric_Campus> totalCampusElectricList = null;
            [TestInitialize]
            public void Setup()
            {
                totalCampusElectricList = new List<Electric_Campus> 
                { 
                    new Electric_Campus { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric_Campus { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric_Campus { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void Total_Campus_ELECTRIC_Records_Match()
            {
                var totalCampusElectricRepo = new Electric_Campus_SQL_Repository();
                Assert.AreEqual(3, totalCampusElectricList.Count);

                var result = totalCampusElectricRepo.Create(totalCampusElectricList);
                Assert.AreEqual(totalCampusElectricList.Count, result);
            }


            [TestMethod]
            public void Total_Campus_ELECTRIC_CanGetToday()
            {
                var totalCampusElectricRepo = new Electric_Campus_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var result = totalCampusElectricRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Electric_Campus), "Not an instance of Total Campus Electric");

            }
            [TestMethod]
            public void Total_Campus_ELECTRIC_CanGetByTime()
            {
                var totalCampusElectricRepo = new Electric_Campus_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var result = totalCampusElectricRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void Total_Campus_ELECTRIC_CanGetTimeRange()
            {
                var totalCampusElectricRepo = new Electric_Campus_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-12 22:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-13 00:00:00.000");

                var result = totalCampusElectricRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Electric_Campus), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
