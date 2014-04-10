using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Steam_Campus_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<SteamDailyTotals_Campus,Steam>
    {
       
        public int Create(List<Core.Models.Steam> entityList)
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
        
       
        public Core.Models.SteamDailyTotals_Campus Get(DateTime dateTime)
        {
           
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusSteamDailyTotals = ctx.TC_STEAM_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return totalCampusSteamDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.SteamDailyTotals_Campus> Get(DateTime startTime, DateTime endTime)
        {
           
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusSteamDailyTotalsList = ctx.TC_STEAM_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return totalCampusSteamDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
