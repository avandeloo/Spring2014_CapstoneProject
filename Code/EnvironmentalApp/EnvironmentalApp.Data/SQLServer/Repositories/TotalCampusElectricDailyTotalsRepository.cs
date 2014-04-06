using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class TotalCampusElectricDailyTotalsRepository:BaseRepository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<ElectricDailyTotals,Electric>
    {
      
        public int Create(List<Core.Models.Electric> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusElectricDailyTotalsList = new List<ElectricDailyTotals>();
                    for (int i = 0; i < totalCampusElectricDailyTotalsList.Count; i++)
                    {
                        ctx.TC_ELECTRICITY_SUM_BY_DAY.Add(totalCampusElectricDailyTotalsList[i]);
                        
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
        
       
        public Core.Models.ElectricDailyTotals Get(DateTime dateTime)
        {
            var totalCampusElectricDailyTotals = new ElectricDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusElectricDailyTotals = ctx.TC_ELECTRICITY_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return totalCampusElectricDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.ElectricDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var totalCampusElectricDailyTotalsList = new List<ElectricDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusElectricDailyTotalsList = ctx.TC_ELECTRICITY_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return totalCampusElectricDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
