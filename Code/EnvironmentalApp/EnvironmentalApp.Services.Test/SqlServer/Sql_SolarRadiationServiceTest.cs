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
    public class Sql_SolarRadiationServiceTest
    {
        private List<SolarRadiation> solarRadiationList = null;
        private SolarRadiation solarRadiationRecord = null;

        [TestInitialize]
        public void Setup()
        {
            solarRadiationList = new List<SolarRadiation> 
                { 
                    new SolarRadiation { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Today.AddDays(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new SolarRadiation { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new SolarRadiation { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Today.AddDays(-1).AddHours(-2), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };

            solarRadiationRecord = new SolarRadiation { Id = Guid.NewGuid(), Reading = 40.2f, ReadingDateTime = DateTime.Today.AddDays(-4), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600 };

        }

        // Solar Radiation

        [TestMethod]
        public void Can_Create_SolarRadiation_Record()
        {
            var SolarRadiationRepo = new Sql_SolarRadiationService();

            var result = SolarRadiationRepo.Create_SolarRadiation_Record(solarRadiationRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Create_SolarRadiation_List_Of_Records()
        {
            var SolarRadiationRepo = new Sql_SolarRadiationService();

            var result = SolarRadiationRepo.Create_SolarRadiation_List_Of_Records(solarRadiationList);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SolarRadiation_ByTime()
        {
            var SolarRadiationRepo = new Sql_SolarRadiationService();
            var dateTime = Convert.ToDateTime("2014-04-15 00:00:00.000");
            var result = SolarRadiationRepo.Get_SolarRadiation_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SolarRadiation), "Not an instance of Solar Radiation");
        }

        [TestMethod]
        public void Can_Get_SolarRadiation_ByDateRange()
        {
            var SolarRadiationRepo = new Sql_SolarRadiationService();
            var startDate = Convert.ToDateTime("2014-04-13 22:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-16 01:51:11.127");
            var result = SolarRadiationRepo.Get_SolarRadiation_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SolarRadiation), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

        // Solar Radiation Daily Totals

        [TestMethod]
        public void Can_Create_SolarRadiationDailyTotals()
        {
            var SolarRadiationRepo = new Sql_SolarRadiationService();
            var startDate = Convert.ToDateTime("2014-04-15 00:00:00.000");
            var endDate = Convert.ToDateTime("2014-04-15 00:00:00.000");

            var result = SolarRadiationRepo.Create_SolarRadiation_DailyTotals(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_SolarRadiationDailyTotals_ByTime()
        {
            var SolarRadiationDailyTotalsRepo = new Sql_SolarRadiationService();
            var dateTime = Convert.ToDateTime("2014-04-16 01:49:45.967");
            var result = SolarRadiationDailyTotalsRepo.Get_SolarRadiationDailyTotals_ByTime(dateTime);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsInstanceOfType(result, typeof(Core.Models.SolarRadiationDailyTotals), "Not an instance of Solar Radiation Daily Totals");
        }

        [TestMethod]
        public void Can_Get_SolarRadiationDailyTotals_ByDateRange()
        {
            var SolarRadiationDailyTotalsRepo = new Sql_SolarRadiationService();
            var startDate = Convert.ToDateTime("2014-04-16 01:49:45.967");
            var endDate = Convert.ToDateTime("2014-04-16 01:49:45.967");
            var result = SolarRadiationDailyTotalsRepo.Get_SolarRadiationDailyTotals_ByTime(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.SolarRadiationDailyTotals), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }

    }

}
