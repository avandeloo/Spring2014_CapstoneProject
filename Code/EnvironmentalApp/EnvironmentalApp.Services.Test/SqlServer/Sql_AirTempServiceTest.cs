using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Services.SQLServerServices;
using EnvironmentalApp.Core.Models;


namespace EnvironmentalApp.Services.Tests.SqlServer
{
    [TestClass]
    public class Sql_AirTempServiceTest
    {
        private List<AirTemp> airTempList = null;
        private AirTemp airTempRecord = null;
        [TestInitialize]
        public void Setup()
        {
            airTempList = new List<AirTemp> 
                { 
                    new AirTemp { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new AirTemp { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new AirTemp { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            airTempRecord = new AirTemp { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };
        }

        // Air Temp

        [TestMethod]
        public void Can_Create_AirTemp()
        {
            var airTempRepo = new Sql_AirTempService();
            var result = airTempRepo.Create_AirTemp_Record(airTempRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_AirTemp_List()
        {
            var airTempRepo = new Sql_AirTempService();
            var result = airTempRepo.Create_AirTemp_List_Of_Records(airTempList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_AirTemp_ByTime()
        {
            var airTempRepo = new Sql_AirTempService();
            var dateTime = Convert.ToDateTime("2014-04-14 22:00:00.000");
            var result = airTempRepo.Get_AirTemp_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.AirTemp), "Not an instance of Air Temp");
        }

        [TestMethod]
        public void Can_Get_AirTemp_ByDateRange()
        {
            var airTempRepo = new Sql_AirTempService();
            var startDate = Convert.ToDateTime("2014-04-14 22:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-15 00:00:00.000");
            var result = airTempRepo.Get_AirTemp_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.AirTemp), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Air Temp Daily Totals

        [TestMethod]
        public void Can_Create_AirTempDailyTotals()
        {
            var airTempRepo = new Sql_AirTempService();
            var startDate = Convert.ToDateTime("2014-04-14 22:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-15 00:00:00.000");

            var result = airTempRepo.Create_AirTemp_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_AirTempDailyTotals_ByTime()
        {
            var airTempDailyTotalsRepo = new Sql_AirTempService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.513");
            var result = airTempDailyTotalsRepo.Get_AirTempDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_AirTempDailyTotals_ByDateRange()
        {
            var airTempDailyTotalsRepo = new Sql_AirTempService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.513");
            var endDate = Convert.ToDateTime("2014-04-16 16:03:06.027");
            var result = airTempDailyTotalsRepo.Get_AirTempDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.AirTempDailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }

}
