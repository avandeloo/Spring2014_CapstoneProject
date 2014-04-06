using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class UnfinishedAirTempDailyTotals:BaseRepository, Core.Data.SQLServer.IAirTempRepository
    {
        public int Create(Core.Models.AirTempDailyTotals entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.PBB_CHILLED_WATER_SUM_BY_DAY.Add(entity);
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
                    var pbbChilledWaterDailyTotalsList = new List<ChilledWaterDailyTotals>();
                    for (int i = 0; i < pbbChilledWaterDailyTotalsList.Count; i++)
                    {
                        ctx.PBB_CHILLED_WATER_SUM_BY_DAY.Add(pbbChilledWaterDailyTotalsList[i]);
                        
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
                    var pbbChilledWaterDailyTotals = ctx.PBB_CHILLED_WATER_SUM_BY_DAY.FirstOrDefault(x => x.Id == entity.Id);
                    if (pbbChilledWaterDailyTotals == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    pbbChilledWaterDailyTotals.Id = entity.Id;
                    pbbChilledWaterDailyTotals.ReadingDateTime = entity.ReadingDateTime;
                    pbbChilledWaterDailyTotals.HighValue = entity.HighValue;
                    pbbChilledWaterDailyTotals.LowValue = entity.LowValue;
                    pbbChilledWaterDailyTotals.DailySum = entity.DailySum;
                    pbbChilledWaterDailyTotals.DailyAverage = entity.DailyAverage;
                    
                    ctx.Entry(pbbChilledWaterDailyTotals).State = System.Data.Entity.EntityState.Modified;

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
