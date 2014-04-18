using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Wind_DailyTotals_SQL_Repository : Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<WindDailyTotals, Wind>
    {

        public int Create(List<Core.Models.Wind> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    var dailyTotals = new WindDailyTotals();
                    var readings = (List<decimal>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.WIND_SUM_BY_DAY.Add(dailyTotals);

                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public Core.Models.WindDailyTotals Get(DateTime dateTime)
        {
            var totals = new WindDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                   totals = ctx.WIND_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                   return totals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.WindDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var windList = new List<WindDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    windList = ctx.WIND_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return windList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
