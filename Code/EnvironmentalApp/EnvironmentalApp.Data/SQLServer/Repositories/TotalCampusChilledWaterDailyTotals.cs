using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class TotalCampusChilledWaterDailyTotals:BaseRepository, Core.Data.SQLServer.IChilledWaterRepository
    {
        public int Create(Core.Models.ChilledWaterDailyTotals entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.TC_CHILLED_WATER_SUM_BY_DAY.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.ChilledWaterDailyTotals> entityList)
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
        
        public int Update(Core.Models.ChilledWaterDailyTotals entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusChilledWaterDailyTotals = ctx.TC_CHILLED_WATER_SUM_BY_DAY.FirstOrDefault(x => x.Id == entity.Id);
                    if (totalCampusChilledWaterDailyTotals == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    totalCampusChilledWaterDailyTotals.Id = entity.Id;
                    totalCampusChilledWaterDailyTotals.ReadingDateTime = entity.ReadingDateTime;
                    totalCampusChilledWaterDailyTotals.HighValue = entity.HighValue;
                    totalCampusChilledWaterDailyTotals.LowValue = entity.LowValue;
                    totalCampusChilledWaterDailyTotals.DailySum = entity.DailySum;
                    totalCampusChilledWaterDailyTotals.DailyAverage = entity.DailyAverage;

                    ctx.Entry(totalCampusChilledWaterDailyTotals).State = System.Data.Entity.EntityState.Modified;

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
