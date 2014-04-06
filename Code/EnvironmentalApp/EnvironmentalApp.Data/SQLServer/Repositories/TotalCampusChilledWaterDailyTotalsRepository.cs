using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class TotalCampusChilledWaterDailyTotalsRepository:BaseRepository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<ChilledWaterDailyTotals,ChilledWater>
    {
        public int Create(List<Core.Models.ChilledWater> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusChilledWaterDailyTotalsList = new List<ChilledWaterDailyTotals>();
                    for (int i = 0; i < totalCampusChilledWaterDailyTotalsList.Count; i++)
                    {
                        ctx.TC_CHILLED_WATER_SUM_BY_DAY.Add(totalCampusChilledWaterDailyTotalsList[i]);
                        
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
        
       

        public Core.Models.ChilledWaterDailyTotals Get(DateTime dateTime)
        {
            var totalCampusChilledWaterDailyTotals = new ChilledWaterDailyTotals();
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

        public List<Core.Models.ChilledWaterDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var totalCampusChilledWaterDailyTotalsList = new List<ChilledWaterDailyTotals>();
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
