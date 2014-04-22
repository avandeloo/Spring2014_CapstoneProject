using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Humidity_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<HumidityDailyTotals,Humidity>
    {


        public int Create(List<Core.Models.Humidity> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    var dailyTotals = new HumidityDailyTotals();
                    var readings = (List<float>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.HUMIDITY_SUM_BY_DAY.Add(dailyTotals);

                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
      
        public Core.Models.HumidityDailyTotals Get(DateTime dateTime)
        {
            var totals = new HumidityDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totals = ctx.HUMIDITY_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return totals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.HumidityDailyTotals> Get(DateTime startTime, DateTime endTime)
        {

            var humidityTotalsList = new List<HumidityDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    humidityTotalsList = ctx.HUMIDITY_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return humidityTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
