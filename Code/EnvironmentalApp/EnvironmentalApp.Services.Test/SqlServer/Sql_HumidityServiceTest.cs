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
    public class Sql_HumidityServiceTest
    {
        private List<Humidity> humidityList = null;
        private Humidity humidityRecord = null;

        [TestInitialize]
        public void Setup()
        {
            humidityList = new List<Humidity> 
                { 
                    new Humidity { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Humidity { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Humidity { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            humidityRecord = new Humidity { Id = Guid.NewGuid(), Reading = 40.2m, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

        }

        // Humidity

        [TestMethod]
        public void Can_Create_Humidity_Record()
        {
            var HumidityRepo = new Sql_HumidityService();
            var result = HumidityRepo.Create_Humidity_Record(humidityRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_Humidity_List_Of_Records()
        {
            var HumidityRepo = new Sql_HumidityService();

            var result = HumidityRepo.Create_Humidity_List_Of_Records(humidityList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_Humidity_ByTime()
        {
            var HumidityRepo = new Sql_HumidityService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = HumidityRepo.Get_Humidity_ByTime(dateTime);
            
            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Humidity), "Not an instance of Air Temp");
        }
        
        [TestMethod]
        public void Can_Get_Humidity_ByDateRange()
        {
            var HumidityRepo = new Sql_HumidityService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = HumidityRepo.Get_Humidity_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Humidity), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Humidity Daily Totals

        [TestMethod]
        public void Can_Create_HumidityDailyTotals()
        {
            var HumidityRepo = new Sql_HumidityService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = HumidityRepo.Create_Humidity_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_HumidityDailyTotals_ByTime()
        {
            var HumidityDailyTotalsRepo = new Sql_HumidityService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:52.977");
            var result = HumidityDailyTotalsRepo.Get_HumidityDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.HumidityDailyTotals), "Not an instance of Air Temp Daily Totals");
        }

        [TestMethod]
        public void Can_Get_HumidityDailyTotals_ByDateRange()
        {
            var HumidityDailyTotalsRepo = new Sql_HumidityService();
            var startDate = Convert.ToDateTime("2014-04-16 02:16:19.500");
            var endDate = Convert.ToDateTime("2014-04-16 17:46:00.833");
            var result = HumidityDailyTotalsRepo.Get_HumidityDailyTotals_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.HumidityDailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }
        
    }
    
}
