using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Electric_Campus_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<ElectricDailyTotals_Campus,Electric_Campus>
    {

        public int Create(List<Core.Models.Electric_Campus> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    var dailyTotals = new ElectricDailyTotals_Campus();
                    var readings = (List<float>)entityList.Select(x => x.Reading).ToList();

                    dailyTotals.Id = Guid.NewGuid();
                    dailyTotals.ReadingDateTime = DateTime.Now;
                    dailyTotals.DailySum = SumReadings(readings);
                    dailyTotals.DailyAverage = AverageReadings(readings);
                    dailyTotals.HighValue = MaxReading(readings);
                    dailyTotals.LowValue = MinReading(readings);

                    ctx.TC_ELECTRICITY_SUM_BY_DAY.Add(dailyTotals);

                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
       
        public Core.Models.ElectricDailyTotals_Campus Get(DateTime dateTime)
        {
            var totalCampusElectricDailyTotals = new ElectricDailyTotals_Campus();
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

        public List<Core.Models.ElectricDailyTotals_Campus> Get(DateTime startTime, DateTime endTime)
        {
            var totalCampusElectricDailyTotalsList = new List<ElectricDailyTotals_Campus>();
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
