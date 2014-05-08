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
    public class Sql_ReportServiceTest
    {
        private Report reportRecord = null;

        [TestInitialize]
        public void Setup()
        {
            reportRecord = new Report { ReportID = Guid.NewGuid(), Name = "Jon's Report", StartDate = DateTime.Now.AddDays(-1).Date, EndDate = DateTime.Now, StartTime = DateTime.Now.AddHours(-1).TimeOfDay, EndTime = DateTime.Now.TimeOfDay, DataType = "Hi, I'm Working Now", GraphStyle = "Bar, Line, Pie", DateCreated = DateTime.Now, GeneratedBy = "Jon", Active = false, UpdatedDate = DateTime.Now, UpdatedBy = "Jon" };

        }

        // Report

        [TestMethod]
        public void Can_Create_Report_Record()
        {
            var reportRepo = new Sql_ReportService();
            var result = reportRepo.Create_Report_Record(reportRecord);

            Assert.IsNotNull(result, "Object is null");
        }

        [TestMethod]
        public void Can_Get_Report_ByName()
        {
            var reportRepo = new Sql_ReportService();
            var reportName = "Jon's Report";
            var result = reportRepo.Get_Report_ByName(reportName);

            Assert.IsNotNull(result, "Object is null");
//            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Report), "Collection does not contain the correct object type");
        }

        //[TestMethod]
        //public void Can_Get_Report_ByGeneratedBy()
        //{
        //    var reportRepo = new Sql_ReportService();
        //    var generatedByName = "Jon";
        //    var result = reportRepo.Get_Report_ByPropertyName_And_Value("GeneratedBy", generatedByName);

        //    Assert.IsNotNull(result, "Object is null");
        //    CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Report), "Collection does not contain the correct object type");

        //}

        [TestMethod]
        public void Can_Update_Report()
        {
            var reportRepo = new Sql_ReportService();
            var reportList = new Report();
            reportList = reportRepo.Get_Report_ByName("Jon's Report");

            reportList.UpdatedBy = "Scott";

            var result = reportRepo.Update_Report_Record(reportList);

            Assert.IsNotNull(result, "Object is null");
            Assert.IsTrue(result == 1, "Number of records doesn't match");

            var Check = reportRepo.Get_Report_ByName("Jon's Report");
            Assert.AreEqual(reportList.ReportID, Check.ReportID);

        }

        //[TestMethod]
        //public void Can_Get_Report_ByUpdatedBy()
        //{
        //    var reportRepo = new Sql_ReportService();

        //    var updatedByName = "Scott";
        //    var result = reportRepo.Get_Report_ByPropertyName_And_Value("UpdatedBy", updatedByName);

        //    Assert.IsNotNull(result, "Object is null");
        //    CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Report), "Collection does not contain the correct object type");

        //    Assert.IsTrue(result[0].UpdatedBy == "Scott");
        //}

        [TestMethod]
        public void Can_Get_Report_ByDateRange()
        {
            var reportRepo = new Sql_ReportService();
            var startDate = Convert.ToDateTime("2014-04-28 17:15:03");
            var endDate = Convert.ToDateTime("2014-04-29 18:15:03");
            var result = reportRepo.Get_Report_ByDateRange(startDate, endDate);

            Assert.IsNotNull(result, "Object is null");
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Core.Models.Report), "Collection does not contain the correct object type");
            Assert.IsTrue(result.Count >= 1, "Record set is empty");
        }


        [TestMethod]
        public void Can_Delete_Report()
        {

            var reportRepo = new Sql_ReportService();
            var reportList = new Report();

            reportList = reportRepo.Get_Report_ByName("Jon's Report");
            var report = reportList;
            var result = reportRepo.Delete_Report_Record(report.ReportID);


            Assert.IsNotNull(result, "Object is null");
            var reportCheck = reportRepo.Get_Report_ByName("Jon's Report");

            Assert.AreNotEqual(report.Active, reportCheck.Active);

            Assert.IsFalse(reportCheck.Active);
        }

       
            
                       
        }
    }



