using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.SQLServer;
using EnvironmentalApp.Core.Models;
namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Report_SQL_Repository : Base_SQL_Repository, IReportRepository
    {

        public int Create(Report entity)
        {
            int result = 0;
            using (var ctx = new EnergyDataContext(ConnString))
            {

                if (ctx.SaveChanges() == 1)
                {
                    ctx.REPORTs.Add(entity);
                    result = 1;
                }
            }

            return result;

        }

        public Report GetByReportName(string value)
        {
            var reportList = new Report();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    reportList = ctx.REPORTs.FirstOrDefault(x => x.Name == value);
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
            
        }

        public Report GetByUpdatedBy(string value)
        {
            var reportList = new Report();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    reportList = ctx.REPORTs.FirstOrDefault(x => x.UpdatedBy == value);
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };

        }

        public Report GetByGeneratedBy(string value)
        {
            var reportList = new Report();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    reportList = ctx.REPORTs.FirstOrDefault(x => x.GeneratedBy == value);
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };

        }

        public List<Report> GetByDateCreated(DateTime value)
        {
            var reportList = new List<Report>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    reportList = ctx.REPORTs.AsEnumerable().Where(x => x.DateCreated == Convert.ToDateTime(value)).ToList();
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
            
        }
        
        public List<Report> GetByUpdatedDate(DateTime value)
        {
            var reportList = new List<Report>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    reportList = ctx.REPORTs.AsEnumerable().Where(x => x.UpdatedDate == Convert.ToDateTime(value)).ToList();
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };

        }


        public List<Report> Get(DateTime startDateTime, DateTime endDateTime)
        {
            var reportList = new List<Report>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    reportList = ctx.REPORTs.AsEnumerable().Where(x => x.StartDate >= startDateTime.Date && x.EndDate <= endDateTime.Date && x.StartTime >= startDateTime.TimeOfDay && x.EndTime <= endDateTime.TimeOfDay).ToList();
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }


        public int Update(Report entity)
        {

            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var report = ctx.REPORTs.FirstOrDefault(x => x.ReportID == entity.ReportID);
                    if (report == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    report.ReportID = entity.ReportID;
                    report.Name = entity.Name;
                    report.StartDate = entity.StartDate;
                    report.EndDate = entity.EndDate;
                    report.StartTime = entity.StartTime;
                    report.EndTime = entity.EndTime;
                    report.DataType = entity.DataType;
                    report.GraphStyle = entity.GraphStyle;
                    report.DateCreated = entity.DateCreated;
                    report.GeneratedBy = entity.GeneratedBy;
                    report.Active = entity.Active;
                    report.UpdatedDate = entity.UpdatedDate;
                    report.UpdatedBy = entity.UpdatedBy;

                    ctx.Entry(report).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Guid reportId)
        {

            using (var ctx = new EnergyDataContext(ConnString))
            {
                var report = ctx.REPORTs.FirstOrDefault(x => x.ReportID == reportId);

                if (report != null)
                {
                    report.Active = true;

                }
                int result = ctx.SaveChanges();
                return result;
            }

        }


    }
}
