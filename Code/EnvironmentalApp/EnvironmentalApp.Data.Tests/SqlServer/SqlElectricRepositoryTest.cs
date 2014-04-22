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
    public class SqlElectricRepositoryTest
    {

            private List<Electric> electricList = null;
            [TestInitialize]
            public void Setup()
            {
                electricList = new List<Electric> 
                { 
                    new Electric { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void PBB_ELECTRIC_Records_Match()
            {
                var PBBElectricRepo = new Electric_SQL_Repository();
                Assert.AreEqual(3, electricList.Count);

                var result = PBBElectricRepo.Create(electricList);
                Assert.AreEqual(electricList.Count, result);
            }


            [TestMethod]
            public void PBB_ELECTRIC_CanGetToday()
            {
                var PBBElectricRepo = new Electric_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
                var result = PBBElectricRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");
                Assert.IsInstanceOfType(result, typeof(Core.Models.Electric), "Not an instance of PBB Electric");

            }
            [TestMethod]
            public void PBB_ELECTRIC_CanGetByTime()
            {
                var PBBElectricRepo = new Electric_SQL_Repository();
                var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
                var result = PBBElectricRepo.Get(dateTime);

                Assert.IsNotNull(result, "Object is null");

            }
            [TestMethod]
            public void PBB_ELECTRIC_CanGetTimeRange()
            {
                var PBBElectricRepo = new Electric_SQL_Repository();
                var startTime = Convert.ToDateTime("2014-04-10 23:00:00.000");
                var endTime = Convert.ToDateTime("2014-04-12 23:00:00.000");

                var result = PBBElectricRepo.Get(startTime, endTime);

                Assert.IsNotNull(result, "Object is null");
                CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Electric), "Collection does not contain the correct object type");
                Assert.IsTrue(result.Count >= 1, "Record set is empty");
            }

        }
    }
