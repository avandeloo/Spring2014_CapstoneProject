using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Solar_CarCharger_DailyTotals_SQL_Repository : Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<SolarDailyTotals_CarCharger, Solar_CarCharger>
    {

            public int Create(List<Core.Models.Solar_CarCharger> entityList)
            {
                try
                {
                    using (var ctx = new EnergyDataContext(ConnString))
                    {
                     
                        var dailyTotals = new SolarDailyTotals_CarCharger();
                        var readings = (List<float>)entityList.Select(x => x.Reading).ToList();

                        dailyTotals.Id = Guid.NewGuid();
                        dailyTotals.ReadingDateTime = entityList[0].ReadingDateTime.Date;
                        dailyTotals.DailySum = SumReadings(readings);
                        dailyTotals.DailyAverage = AverageReadings(readings);
                        dailyTotals.HighValue = MaxReading(readings);
                        dailyTotals.LowValue = MinReading(readings);

                        ctx.SOLAR_CAR_CHARGING_SUM_BY_DAY.Add(dailyTotals);

                        int result = ctx.SaveChanges();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            public Core.Models.SolarDailyTotals_CarCharger Get(DateTime dateTime)
            {
                var solarCarChargerDailyTotals = new SolarDailyTotals_CarCharger();
                try
                {
                    using (var ctx = new EnergyDataContext(ConnString))
                    {
                        solarCarChargerDailyTotals = ctx.SOLAR_CAR_CHARGING_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                        return solarCarChargerDailyTotals;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public List<Core.Models.SolarDailyTotals_CarCharger> Get(DateTime startTime, DateTime endTime)
            {
                var solarCarChargerDailyTotalsList = new List<SolarDailyTotals_CarCharger>();
                try
                {
                    using (var ctx = new EnergyDataContext(ConnString))
                    {
                        solarCarChargerDailyTotalsList = ctx.SOLAR_CAR_CHARGING_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                        return solarCarChargerDailyTotalsList;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
      
    }
