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

                    var dailyTotals = new SolarDailyTotals_BusBarn();
                    var readings = (List<decimal>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.SOLAR_BUS_BARN_SUM_BY_DAY.Add(dailyTotals);

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
