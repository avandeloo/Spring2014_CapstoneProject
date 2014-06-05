using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.SQLServer;
using EnvironmentalApp.Core.Models;
using System.Data.Entity.Validation;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Report_SQL_Repository : Base_SQL_Repository, IReportRepository
    {

        public int Create(Report entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    entity.Active = true;
                    ctx.REPORTs.Add(entity);
                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Report> GetAll()
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                   var  reportList = ctx.REPORTs.AsEnumerable().ToList();
                    return reportList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
            
        
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
        
        public List<Report> GetByUpdateDate(DateTime value)
        {
            var reportList = new List<Report>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    reportList = ctx.REPORTs.AsEnumerable().Where(x => x.UpdateDate == Convert.ToDateTime(value)).ToList();
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
                    report.UpdateDate = entity.UpdateDate;
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
