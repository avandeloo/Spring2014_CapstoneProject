using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.SQLServer;
using EnvironmentalApp.Core.Models;
namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Report_SQL_Repository:Base_SQL_Repository, IReportRepository
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

        public List<Report> Get(string propertyName, string value)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
            }
            throw new NotImplementedException();
        }

        public List<Report> Get(DateTime startDateTime, DateTime endDateTime)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
            }
            throw new NotImplementedException();
        }

        public int Update(Report entity)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
            }
            throw new NotImplementedException();
        }

        public int Delete(Guid reportId)
        {
            using (var ctx = new EnergyDataContext(ConnString))
            {
            }
            throw new NotImplementedException();
        }
    }
}
