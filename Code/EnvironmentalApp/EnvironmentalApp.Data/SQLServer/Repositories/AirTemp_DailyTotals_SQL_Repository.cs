using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class AirTemp_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<AirTempDailyTotals,AirTemp>
    {
      
        public int Create(List<Core.Models.AirTemp> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var airTempTotals = new List<AirTempDailyTotals>();

                    var readings = entityList.Select(x => x.Reading);
                    var entityTotals = entityList.GroupBy(g => g.ReadingDateTime.Date)
                                                .Select(x => new
                                                {
                                                    id = Guid.NewGuid(),
                                                    date = x.Select(y => y.ReadingDateTime),
                                                    sum = x.Sum(y => Convert.ToDecimal(y.Reading)),
                                                    avg = x.Average(y => Convert.ToDecimal(y.Reading)),
                                                    max = x.Max(y => Convert.ToDecimal(y.Reading)),
                                                    min = x.Min(y => Convert.ToDecimal(y.Reading))
                                                });
                    
                    airTempTotals = entityTotals.AsEnumerable().Select(b => new AirTempDailyTotals
                    {
                        Id = b.id,
                        ReadingDateTime = DateTime.Now,
                        DailySum = b.sum,
                        DailyAverage = b.avg,
                        HighValue = b.max,
                        LowValue = b.min
                    }).ToList();

                    for (int i = 0; i < airTempTotals.Count; i++)
                    {
                        ctx.AIR_TEMP_SUM_BY_DAY.Add(airTempTotals[i]);
                    }

                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Core.Models.AirTempDailyTotals Get(DateTime dateTime)
        {
            var totals = new AirTempDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                   return totals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.AirTempDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var airTempTotalsList = new List<AirTempDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    return airTempTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
