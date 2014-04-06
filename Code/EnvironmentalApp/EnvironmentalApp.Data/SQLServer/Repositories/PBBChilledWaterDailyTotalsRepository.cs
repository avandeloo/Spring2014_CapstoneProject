using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class PBBChilledWaterDailyTotalsRepository:BaseRepository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<ChilledWaterDailyTotals,ChilledWater>
    {
 

        public int Create(List<Core.Models.ChilledWater> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
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
            var pbbChilledWaterDailyTotals = new ChilledWaterDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    pbbChilledWaterDailyTotals = ctx.PBB_CHILLED_WATER_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return pbbChilledWaterDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.ChilledWaterDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var pbbChilledWaterDailyTotalsList = new List<ChilledWaterDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    pbbChilledWaterDailyTotalsList = ctx.PBB_CHILLED_WATER_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return pbbChilledWaterDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
