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
        public static decimal sum = 0;
        public static decimal average = 0;
        public static decimal max = 0;
        public static decimal min;
        public static int count = 0;

        public int Create(List<Core.Models.Electric> entityList)
        {
         
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var pbbElectricDailyTotalsList = new List<ElectricDailyTotals>();

                    var entityValues = entityList.Select(x => new
                                                {
                                                    date = x.ReadingDateTime,
                                                    value = Convert.ToDecimal(x.Reading),
                                                    
                                                });
                    
                    foreach (var item in entityValues)
                    {
                        var e = entityValues.First();
                        min = e.value;
                        break;
                    }
                    
                    foreach (var item in entityValues)
                    {
                        sum += item.value;
                        count += 1;
                        if (item.value > max)
                        {
                            max = item.value;
                        }
                        if (item.value < min)
                        {
                            min = item.value;
                        }
                    }
                    average = sum / count;

                    pbbElectricDailyTotalsList.AsEnumerable().Select(b => new AirTempDailyTotals
                    {
                        Id = Guid.NewGuid(),
                        ReadingDateTime = DateTime.Now,
                        DailySum = sum,
                        DailyAverage = average,
                        HighValue = max,
                        LowValue = min
                    }).ToList();

                    for (int i = 0; i < pbbElectricDailyTotalsList.Count; i++)
                    {
                        ctx.PBB_ELECTRIC_SUM_BY_DAY.Add(pbbElectricDailyTotalsList[i]);
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
