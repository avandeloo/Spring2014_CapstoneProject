using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class ChilledWater_Campus_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<CW_DailyTotals_Campus,ChilledWater>
    {
        public int Create(List<Core.Models.ChilledWater_Campus> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    var dailyTotals = new CW_DailyTotals_Campus();
                    var readings = (List<decimal>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.TC_CHILLED_WATER_SUM_BY_DAY.Add(dailyTotals);

                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Core.Models.CW_DailyTotals_Campus Get(DateTime dateTime)
        {
            var totalCampusChilledWaterDailyTotals = new CW_DailyTotals_Campus();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusChilledWaterDailyTotals = ctx.TC_CHILLED_WATER_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return totalCampusChilledWaterDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.CW_DailyTotals_Campus> Get(DateTime startTime, DateTime endTime)
        {
            var totalCampusChilledWaterDailyTotalsList = new List<CW_DailyTotals_Campus>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusChilledWaterDailyTotalsList = ctx.TC_CHILLED_WATER_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return totalCampusChilledWaterDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
