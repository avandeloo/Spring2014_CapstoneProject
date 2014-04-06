using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class SolarBusBarnDailyTotalsRepository:BaseRepository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<SolarDailyTotals,Solar>
    {
      
        public int Create(List<Core.Models.Solar> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarBusBarnDailyTotalsList = new List<SolarDailyTotals>();
                    for (int i = 0; i < solarBusBarnDailyTotalsList.Count; i++)
                    {
                        ctx.SOLAR_BUS_BARN_SUM_BY_DAY.Add(solarBusBarnDailyTotalsList[i]);
                        
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
        
       
        public Core.Models.SolarDailyTotals Get(DateTime dateTime)
        {
            var solarBusBarnDailyTotals = new SolarDailyTotals();
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

        public List<Core.Models.SolarDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var solarBusBarnDailyTotalsList = new List<SolarDailyTotals>();
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
