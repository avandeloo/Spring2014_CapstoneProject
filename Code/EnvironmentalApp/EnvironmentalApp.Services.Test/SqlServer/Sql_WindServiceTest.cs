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
    public class Sql_WindServiceTest
    {
        private List<Wind> windList = null;
        private Wind windRecord = null;
        [TestInitialize]
        public void Setup()
        {
            windList = new List<Wind> 
                { 
                    new Wind { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Wind { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Wind { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            windRecord = new Wind { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };
        }

        // Wind

        [TestMethod]
        public void Can_Create_Wind()
        {
            var windRepo = new Sql_WindService();
            var result = windRepo.Create_Wind_Record(windRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_Wind_List()
        {
            var windRepo = new Sql_WindService();
            var result = windRepo.Create_Wind_List_Of_Records(windList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_Wind_ByTime()
        {
            var windRepo = new Sql_WindService();
            var dateTime = Convert.ToDateTime("2014-04-14 22:00:00.000");
            var result = windRepo.Get_Wind_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Wind), "Not an instance of Wind");
        }

        [TestMethod]
        public void Can_Get_Wind_ByDateRange()
        {
            var windRepo = new Sql_WindService();
            var startDate = Convert.ToDateTime("2014-04-14 22:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-15 00:00:00.000");
            var result = windRepo.Get_Wind_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Wind), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Wind Daily Totals

        [TestMethod]
        public void Can_Create_WindDailyTotals()
        {
            var windRepo = new Sql_WindService();
            var startDate = Convert.ToDateTime("2014-04-14 22:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-15 00:00:00.000");

            var result = windRepo.Create_Wind_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_WindDailyTotals_ByTime()
        {
            var windDailyTotalsRepo = new Sql_WindService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.513");
            var result = windDailyTotalsRepo.Get_WindDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_WindDailyTotals_ByDateRange()
        {
            var windDailyTotalsRepo = new Sql_WindService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.513");
            var endDate = Convert.ToDateTime("2014-04-16 16:03:06.027");
            var result = windDailyTotalsRepo.Get_WindDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.WindDailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }

}
