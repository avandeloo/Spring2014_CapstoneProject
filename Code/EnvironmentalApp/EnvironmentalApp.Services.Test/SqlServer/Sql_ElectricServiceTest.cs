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
    public class Sql_ElectricServiceTest
    {
        private List<Electric> electricList = null;
        private Electric electricRecord = null;
        private List<Electric_Campus> electricCampusList = null;
        private Electric_Campus electricCampusRecord = null;

        [TestInitialize]
        public void Setup()
        {
            electricList = new List<Electric> 
                { 
                    new Electric { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            electricRecord = new Electric { Id = Guid.NewGuid(), Reading = 40.2m, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

            electricCampusList = new List<Electric_Campus> 
                { 
                    new Electric_Campus { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric_Campus { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Electric_Campus { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            electricCampusRecord = new Electric_Campus { Id = Guid.NewGuid(), Reading = 40.2m, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

        }

        // Electric

        [TestMethod]
        public void Can_Create_Electric_Record()
        {
            var ElectricRepo = new Sql_ElectricService();
            var result = ElectricRepo.Create_Electric_Record(electricRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_Electric_List_Of_Records()
        {
            var ElectricRepo = new Sql_ElectricService();

            var result = ElectricRepo.Create_Electric_List_Of_Records(electricList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_Electric_ByTime()
        {
            var ElectricRepo = new Sql_ElectricService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = ElectricRepo.Get_Electric_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Electric), "Not an instance of Electric");
        }

        [TestMethod]
        public void Can_Get_Electric_ByDateRange()
        {
            var ElectricRepo = new Sql_ElectricService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = ElectricRepo.Get_Electric_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Electric), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Electric Daily Totals

        [TestMethod]
        public void Can_Create_ElectricDailyTotals()
        {
            var ElectricDailyTotalsRepo = new Sql_ElectricService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = ElectricDailyTotalsRepo.Create_Electric_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ElectricDailyTotals_ByTime()
        {
            var ElectricDailyTotalsRepo = new Sql_ElectricService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.177");
            var result = ElectricDailyTotalsRepo.Get_ElectricDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.ElectricDailyTotals), "Not an instance of Electric Daily Totals");
        }

        [TestMethod]
        public void Can_Get_ElectricDailyTotals_ByDateRange()
        {
            var ElectricDailyTotalsRepo = new Sql_ElectricService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.177");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:53.177");
            var result = ElectricDailyTotalsRepo.Get_ElectricDailyTotals_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.ElectricDailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }


        // Electric Campus

        [TestMethod]
        public void Can_Create_ElectricCampus_Record()
        {
            var ElectricCampusRepo = new Sql_ElectricService();
            var result = ElectricCampusRepo.Create_ElectricCampus_Record(electricCampusRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_ElectricCampus_List_Of_Records()
        {
            var ElectricCampusRepo = new Sql_ElectricService();

            var result = ElectricCampusRepo.Create_ElectricCampus_List_Of_Records(electricCampusList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ElectricCampus_ByTime()
        {
            var ElectricCampusRepo = new Sql_ElectricService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = ElectricCampusRepo.Get_ElectricCampus_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Electric_Campus), "Not an instance of Electric Campus");
        }

        [TestMethod]
        public void Can_Get_ElectricCampus_ByDateRange()
        {
            var ElectricCampusRepo = new Sql_ElectricService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = ElectricCampusRepo.Get_ElectricCampus_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Electric_Campus), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Electric Campus Daily Totals

        [TestMethod]
        public void Can_Create_ElectricCampusDailyTotals()
        {
            var ElectricCampusDailyTotalsRepo = new Sql_ElectricService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = ElectricCampusDailyTotalsRepo.Create_ElectricCampus_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ElectricCampusDailyTotals_ByTime()
        {
            var ElectricCampusDailyTotalsRepo = new Sql_ElectricService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.267");
            var result = ElectricCampusDailyTotalsRepo.Get_ElectricCampusDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.ElectricDailyTotals_Campus), "Not an instance of Electric Campus Daily Totals");
        }

        [TestMethod]
        public void Can_Get_ElectricCampusDailyTotals_ByDateRange()
        {
            var ElectricCampusDailyTotalsRepo = new Sql_ElectricService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.267");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:53.267");
            var result = ElectricCampusDailyTotalsRepo.Get_ElectricCampusDailyTotals_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.ElectricDailyTotals_Campus), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }

}
