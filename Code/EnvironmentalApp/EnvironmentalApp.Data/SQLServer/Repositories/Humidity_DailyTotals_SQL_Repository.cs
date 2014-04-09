using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Humidity_DailyTotals_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBase_DailySumRepository<HumidityDailyTotals,Humidity>
    {
        

        public int Create(List<Core.Models.Humidity> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var humidityTotals = new HumidityDailyTotals();

                    var entityTotals = entityList.GroupBy(g => g.ReadingDateTime)
                                                .Select(x => new
                                                {
                                                    id = Guid.NewGuid(),
                                                    date = x.Select(y => y.ReadingDateTime),
                                                    sum = x.Sum(y => Convert.ToDecimal(y.Reading)),
                                                    avg = x.Average(y => Convert.ToDecimal(y.Reading)),
                                                    max = x.Max(y => Convert.ToDecimal(y.Reading)),
                                                    min = x.Min(y => Convert.ToDecimal(y.Reading))
                                                });


                    
                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
      
        public Core.Models.HumidityDailyTotals Get(DateTime dateTime)
        {
            var totals = new HumidityDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    return totals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.HumidityDailyTotals> Get(DateTime startTime, DateTime endTime)
        {

            var humidityTotalsList = new List<HumidityDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    return humidityTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
