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
    public class Sql_ChilledWaterServiceTest
    {
        private List<ChilledWater> chilledWaterList = null;
        private ChilledWater chilledWaterRecord = null;
        private List<ChilledWater_Campus> chilledWaterCampusList = null;
        private ChilledWater_Campus chilledWaterCampusRecord = null;
        
        [TestInitialize]
        public void Setup()
        {
            chilledWaterList = new List<ChilledWater> 
                { 
                    new ChilledWater { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
        
            chilledWaterRecord = new ChilledWater { Id = Guid.NewGuid(), Reading = 40.2m, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

            chilledWaterCampusList = new List<ChilledWater_Campus> 
                { 
                    new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            chilledWaterCampusRecord = new ChilledWater_Campus { Id = Guid.NewGuid(), Reading = 40.2m, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };
        
        }

        // Chilled Water

        [TestMethod]
        public void Can_Create_ChilledWater_Record()
        {
            var chilledWaterRepo = new Sql_ChilledWaterService();
            var result = chilledWaterRepo.Create_ChilledWater_Record(chilledWaterRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_ChilledWater_List_Of_Records()
        {
            var chilledWaterRepo = new Sql_ChilledWaterService();
            var result = chilledWaterRepo.Create_ChilledWater_List_Of_Records(chilledWaterList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ChilledWater_ByTime()
        {
            var chilledWaterRepo = new Sql_ChilledWaterService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = chilledWaterRepo.Get_ChilledWater_ByTime(dateTime);
            
            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.ChilledWater), "Not an instance of Chilled Water");
        }
        
        [TestMethod]
        public void Can_Get_ChilledWater_ByDateRange()
        {
            var chilledWaterRepo = new Sql_ChilledWaterService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = chilledWaterRepo.Get_ChilledWater_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.ChilledWater), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Chilled Water Daily Totals

        [TestMethod]
        public void Can_Create_ChilledWaterDailyTotals()
        {
            var chilledWaterDailyTotalsRepo = new Sql_ChilledWaterService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = chilledWaterDailyTotalsRepo.Create_ChilledWater_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ChilledWaterDailyTotals_ByTime()
        {
            var chilledWaterDailyTotalsRepo = new Sql_ChilledWaterService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.350");
            var result = chilledWaterDailyTotalsRepo.Get_ChilledWaterDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.CW_DailyTotals), "Not an instance of Chilled Water Daily Totals");
        }

        [TestMethod]
        public void Can_Get_ChilledWaterDailyTotals_ByDateRange()
        {
            var chilledWaterDailyTotalsRepo = new Sql_ChilledWaterService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.350");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:53.350");
            var result = chilledWaterDailyTotalsRepo.Get_ChilledWaterDailyTotals_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.CW_DailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }


        // Chilled Water Campus

        [TestMethod]
        public void Can_Create_ChilledWaterCampus_Record()
        {
            var chilledWaterCampusRepo = new Sql_ChilledWaterService();
            var result = chilledWaterCampusRepo.Create_ChilledWaterCampus_Record(chilledWaterCampusRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_ChilledWaterCampus_List_Of_Records()
        {
            var chilledWaterCampusRepo = new Sql_ChilledWaterService();

            var result = chilledWaterCampusRepo.Create_ChilledWaterCampus_List_Of_Records(chilledWaterCampusList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ChilledWaterCampus_ByTime()
        {
            var chilledWaterCampusRepo = new Sql_ChilledWaterService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = chilledWaterCampusRepo.Get_ChilledWaterCampus_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.ChilledWater_Campus), "Not an instance of Chilled Water Campus");
        }

        [TestMethod]
        public void Can_Get_ChilledWaterCampus_ByDateRange()
        {
            var chilledWaterCampusRepo = new Sql_ChilledWaterService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = chilledWaterCampusRepo.Get_ChilledWaterCampus_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.ChilledWater_Campus), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Chilled Water Campus Daily Totals

        [TestMethod]
        public void Can_Create_ChilledWaterCampusDailyTotals()
        {
            var chilledWaterCampusDailyTotalsRepo = new Sql_ChilledWaterService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = chilledWaterCampusDailyTotalsRepo.Create_ChilledWaterCampus_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_ChilledWaterCampusDailyTotals_ByTime()
        {
            var chilledWaterCampusDailyTotalsRepo = new Sql_ChilledWaterService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:53.437");
            var result = chilledWaterCampusDailyTotalsRepo.Get_ChilledWaterCampusDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.CW_DailyTotals_Campus), "Not an instance of Chilled Water Campus Daily Totals");
        }

        [TestMethod]
        public void Can_Get_ChilledWaterCampusDailyTotals_ByDateRange()
        {
            var chilledWaterCampusDailyTotalsRepo = new Sql_ChilledWaterService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:53.437");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:53.437");
            var result = chilledWaterCampusDailyTotalsRepo.Get_ChilledWaterCampusDailyTotals_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.CW_DailyTotals_Campus), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }
    
}
