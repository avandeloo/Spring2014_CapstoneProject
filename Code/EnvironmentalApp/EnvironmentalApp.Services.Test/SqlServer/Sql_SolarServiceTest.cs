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
    public class Sql_SolarServiceTest
    {
        private List<Solar_CarCharger> solarCarChargerList = null;
        private Solar_CarCharger solarCarChargerRecord = null;
        private List<Solar_BusBarn> solarBusBarnList = null;
        private Solar_BusBarn solarBusBarnRecord = null;

        [TestInitialize]
        public void Setup()
        {
            solarCarChargerList = new List<Solar_CarCharger> 
                { 
                    new Solar_CarCharger { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_CarCharger { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_CarCharger { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            solarCarChargerRecord = new Solar_CarCharger { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

            solarBusBarnList = new List<Solar_BusBarn> 
                { 
                    new Solar_BusBarn { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_BusBarn { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Solar_BusBarn { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            solarBusBarnRecord = new Solar_BusBarn { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

        }

        // Solar Car Charger

        [TestMethod]
        public void Can_Create_SolarCarCharger_Record()
        {
            var solarCarChargerRepo = new Sql_SolarService();
            var result = solarCarChargerRepo.Create_SolarCarCharger_Record(solarCarChargerRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_SolarCarCharger_List_Of_Records()
        {
            var SolarCarChargerRepo = new Sql_SolarService();
            
            var result = SolarCarChargerRepo.Create_SolarCarCharger_List_Of_Records(solarCarChargerList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SolarCarCharger_ByTime()
        {
            var SolarCarChargerRepo = new Sql_SolarService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SolarCarChargerRepo.Get_SolarCarCharger_ByTime(dateTime);
            
            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_CarCharger), "Not an instance of Solar Car Charger");
        }
        
        [TestMethod]
        public void Can_Get_SolarCarCharger_ByDateRange()
        {
            var SolarCarChargerRepo = new Sql_SolarService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SolarCarChargerRepo.Get_SolarCarCharger_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar_CarCharger), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Solar Car Charger Daily Totals

        [TestMethod]
        public void Can_Create_SolarCarChargerDailyTotals()
        {
            var SolarCarChargerDailyTotalsRepo = new Sql_SolarService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = SolarCarChargerDailyTotalsRepo.Create_SolarCarCharger_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SolarCarChargerDailyTotals_ByTime()
        {
            var SolarCarChargerDailyTotalsRepo = new Sql_SolarService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:52.543");
            var result = SolarCarChargerDailyTotalsRepo.Get_SolarCarChargerDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SolarDailyTotals_CarCharger), "Not an instance of Solar Car Charger Daily Totals");
        }

        [TestMethod]
        public void Can_Get_SolarCarChargerDailyTotals_ByDateRange()
        {
            var SolarCarChargerDailyTotalsRepo = new Sql_SolarService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:52.543");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:52.543");
            var result = SolarCarChargerDailyTotalsRepo.Get_SolarCarChargerDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SolarDailyTotals_CarCharger), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }


        // Solar Bus Barn

        [TestMethod]
        public void Can_Create_SolarBusBarn_Record()
        {
            var SolarBusBarnRepo = new Sql_SolarService();
            var result = SolarBusBarnRepo.Create_SolarBusBarn_Record(solarBusBarnRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_SolarBusBarn_List_Of_Records()
        {
            var SolarBusBarnRepo = new Sql_SolarService();

            var result = SolarBusBarnRepo.Create_SolarBusBarn_List_Of_Records(solarBusBarnList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SolarBusBarn_ByTime()
        {
            var SolarBusBarnRepo = new Sql_SolarService();
            var dateTime = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SolarBusBarnRepo.Get_SolarBusBarn_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.Solar_BusBarn), "Not an instance of Solar Bus Barn");
        }

        [TestMethod]
        public void Can_Get_SolarBusBarn_ByDateRange()
        {
            var SolarBusBarnRepo = new Sql_SolarService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");
            var result = SolarBusBarnRepo.Get_SolarBusBarn_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Solar_BusBarn), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Solar Bus Barn Daily Totals

        [TestMethod]
        public void Can_Create_SolarBusBarnDailyTotals()
        {
            var SolarBusBarnDailyTotalsRepo = new Sql_SolarService();
            var startDate = Convert.ToDateTime("2014-04-10 23:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-12 23:00:00.000");

            var result = SolarBusBarnDailyTotalsRepo.Create_SolarBusBarn_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SolarBusBarnDailyTotals_ByTime()
        {
            var SolarBusBarnDailyTotalsRepo = new Sql_SolarService();
            var dateTime = Convert.ToDateTime("2014-04-15 23:55:52.817");
            var result = SolarBusBarnDailyTotalsRepo.Get_SolarBusBarnDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SolarDailyTotals_BusBarn), "Not an instance of Solar Bus Barn Daily Totals");
        }

        [TestMethod]
        public void Can_Get_SolarBusBarnDailyTotals_ByDateRange()
        {
            var SolarBusBarnDailyTotalsRepo = new Sql_SolarService();
            var startDate = Convert.ToDateTime("2014-04-15 23:55:52.817");
            var endDate = Convert.ToDateTime("2014-04-15 23:55:52.817");
            var result = SolarBusBarnDailyTotalsRepo.Get_SolarBusBarnDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SolarDailyTotals_BusBarn), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }
    
}
