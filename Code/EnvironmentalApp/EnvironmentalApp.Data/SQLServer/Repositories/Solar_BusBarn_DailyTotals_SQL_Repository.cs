using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Solar_BusBarn_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<SolarDailyTotals_BusBarn,Solar_BusBarn>
    {

        public int Create(List<Core.Models.Solar_BusBarn> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarBusBarnTotals = new List<SolarDailyTotals_BusBarn>();

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

                    solarBusBarnTotals = entityTotals.AsEnumerable().Select(b => new SolarDailyTotals_BusBarn
                    {
                        Id = b.id,
                        ReadingDateTime = DateTime.Now,
                        DailySum = b.sum,
                        DailyAverage = b.avg,
                        HighValue = b.max,
                        LowValue = b.min
                    }).ToList();

                    for (int i = 0; i < solarBusBarnTotals.Count; i++)
                    {
                        ctx.SOLAR_BUS_BARN_SUM_BY_DAY.Add(solarBusBarnTotals[i]);
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
        
       
        public Core.Models.SolarDailyTotals_BusBarn Get(DateTime dateTime)
        {
            var solarBusBarnDailyTotals = new SolarDailyTotals_BusBarn();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarBusBarnDailyTotals = ctx.SOLAR_BUS_BARN_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return solarBusBarnDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.SolarDailyTotals_BusBarn> Get(DateTime startTime, DateTime endTime)
        {
            var solarBusBarnDailyTotalsList = new List<SolarDailyTotals_BusBarn>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarBusBarnDailyTotalsList = ctx.SOLAR_BUS_BARN_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return solarBusBarnDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
