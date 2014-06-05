using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.SQLServer;
using EnvironmentalApp.Data.SQLServer.Repositories;
using EnvironmentalApp.Core;
using EnvironmentalApp.Data.SQLServer;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Services.SQLServerServices
{
    public class Sql_ReportService
    {
        IReportRepository reportRepo = null;

        public Sql_ReportService()
        {
            reportRepo = new Report_SQL_Repository();
        }

        // Report

        public List<Core.Models.Report> Get_Report_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var reportList = new List<Core.Models.Report>();
            reportList = reportRepo.Get(startDate, endDate);
            return reportList;
        }

        public Core.Models.Report Get_Report_ByName(string value)
        {
            var reportRecord = new Report();
            reportRecord = reportRepo.GetByReportName(value);
            return reportRecord;
        }

        public int Create_Report_Record(Report entity)
        {
            return reportRepo.Create(entity);
        }

        public int Delete_Report_Record(Guid reportID)
        {
            return reportRepo.Delete(reportID);
        }
        public List<Report> GetAllReports()
        {
            return reportRepo.GetAll();
        }
        public int Update_Report_Record(Report entity)
        {
            return reportRepo.Update(entity);
        }

    }
}
