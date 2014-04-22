using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class SolarRadiation_DailyTotals_SQL_Repository : Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<SolarRadiationDailyTotals, SolarRadiation>
    {

        public int Create(List<Core.Models.SolarRadiation> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    var dailyTotals = new SolarRadiationDailyTotals();
                    var readings = (List<float>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.SOLAR_RADIATION_SUM_BY_DAY.Add(dailyTotals);

                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
       
        public Core.Models.SolarRadiationDailyTotals Get(DateTime dateTime)
        {
            var solarRadiationDailyTotals = new SolarRadiationDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarRadiationDailyTotals = ctx.SOLAR_RADIATION_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return solarRadiationDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.SolarRadiationDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var solarRadiationDailyTotalsList = new List<SolarRadiationDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarRadiationDailyTotalsList = ctx.SOLAR_RADIATION_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return solarRadiationDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
