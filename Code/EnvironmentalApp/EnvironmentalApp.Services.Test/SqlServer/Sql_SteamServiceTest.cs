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
    public class Sql_SteamServiceTest
    {
        private List<Steam> steamList = null;
        private Steam steamRecord = null;
        private List<Steam_Campus> steamCampusList = null;
        private Steam_Campus steamCampusRecord = null;

        [TestInitialize]
        public void Setup()
        {
            steamList = new List<Steam> 
                { 
                    new Steam { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            steamRecord = new Steam { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

            steamCampusList = new List<Steam_Campus> 
                { 
                    new Steam_Campus { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam_Campus { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam_Campus { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            steamCampusRecord = new Steam_Campus { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

        }

        // Steam

        [TestMethod]
        public void Can_Create_Steam_Record()
        {
            var SteamRepo = new Sql_SteamService();
            var result = SteamRepo.Create_Steam_Record(steamRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_Steam_List_Of_Records()
        {
            var SteamRepo = new Sql_SteamService();
            
            var result = SteamRepo.Create_Steam_List_Of_Records(steamList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_Steam_ByTime()
        {
            var SteamRepo = new Sql_SteamService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SteamRepo.Get_Steam_ByTime(dateTime);
            
            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Steam), "Not an instance of Steam");
        }
        
        [TestMethod]
        public void Can_Get_Steam_ByDateRange()
        {
            var SteamRepo = new Sql_SteamService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SteamRepo.Get_Steam_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Steam), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Steam Daily Totals

        [TestMethod]
        public void Can_Create_SteamDailyTotals()
        {
            var SteamDailyTotalsRepo = new Sql_SteamService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = SteamDailyTotalsRepo.Create_Steam_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SteamDailyTotals_ByTime()
        {
            var SteamDailyTotalsRepo = new Sql_SteamService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.027");
            var result = SteamDailyTotalsRepo.Get_SteamDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SteamDailyTotals), "Not an instance of Steam Daily Totals");
        }

        [TestMethod]
        public void Can_Get_SteamDailyTotals_ByDateRange()
        {
            var SteamDailyTotalsRepo = new Sql_SteamService();
            var startDate = Convert.ToDateTime("2014-04-14 20:19:44.450");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:53.027");
            var result = SteamDailyTotalsRepo.Get_SteamDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SteamDailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }


        // Steam Campus

        [TestMethod]
        public void Can_Create_SteamCampus_Record()
        {
            var SteamCampusRepo = new Sql_SteamService();
            var result = SteamCampusRepo.Create_SteamCampus_Record(steamCampusRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_SteamCampus_List_Of_Records()
        {
            var SteamCampusRepo = new Sql_SteamService();

            var result = SteamCampusRepo.Create_SteamCampus_List_Of_Records(steamCampusList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SteamCampus_ByTime()
        {
            var SteamCampusRepo = new Sql_SteamService();
            var dateTime = Convert.ToDateTime("2014-04-14 22:55:47.397");
            var result = SteamCampusRepo.Get_SteamCampus_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Steam_Campus), "Not an instance of Steam Campus");
        }

        [TestMethod]
        public void Can_Get_SteamCampus_ByDateRange()
        {
            var SteamCampusRepo = new Sql_SteamService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SteamCampusRepo.Get_SteamCampus_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Steam_Campus), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Steam Campus Daily Totals

        [TestMethod]
        public void Can_Create_SteamCampusDailyTotals()
        {
            var SteamCampusDailyTotalsRepo = new Sql_SteamService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = SteamCampusDailyTotalsRepo.Create_SteamCampus_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SteamCampusDailyTotals_ByTime()
        {
            var SteamCampusDailyTotalsRepo = new Sql_SteamService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.103");
            var result = SteamCampusDailyTotalsRepo.Get_SteamCampusDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SteamDailyTotals_Campus), "Not an instance of Steam Campus Daily Totals");
        }

        [TestMethod]
        public void Can_Get_SteamCampusDailyTotals_ByDateRange()
        {
            var SteamCampusDailyTotalsRepo = new Sql_SteamService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.103");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:53.103");
            var result = SteamCampusDailyTotalsRepo.Get_SteamCampusDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SteamDailyTotals_Campus), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }
    
}
