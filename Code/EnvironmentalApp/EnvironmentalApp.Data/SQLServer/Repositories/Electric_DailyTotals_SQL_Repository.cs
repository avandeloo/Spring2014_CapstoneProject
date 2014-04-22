using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Electric_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<ElectricDailyTotals,Electric>
    {
        public int Create(List<Core.Models.Electric> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                 
                    var dailyTotals = new ElectricDailyTotals();
                    var readings = (List<float>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.PBB_ELECTRIC_SUM_BY_DAY.Add(dailyTotals);

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
            var pbbElectricDailyTotals = new ElectricDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    pbbElectricDailyTotals = ctx.PBB_ELECTRIC_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return pbbElectricDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.ElectricDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var pbbElectricDailyTotalsList = new List<ElectricDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    pbbElectricDailyTotalsList = ctx.PBB_ELECTRIC_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return pbbElectricDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
