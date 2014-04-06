using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class PBBElectricDailyTotals:BaseRepository, Core.Data.SQLServer.ISteamRepository
    {
        public int Create(Core.Models.ElectricDailyTotals entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.PBB_ELECTRIC_SUM_BY_DAY.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.ElectricDailyTotals> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var pbbElectricDailyTotalsList = new List<ElectricDailyTotals>();
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
        
        public int Update(Core.Models.ElectricDailyTotals entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var pbbElectricDailyTotals = ctx.PBB_ELECTRIC_SUM_BY_DAY.FirstOrDefault(x => x.Id == entity.Id);
                    if (pbbElectricDailyTotals == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    pbbElectricDailyTotals.Id = entity.Id;
                    pbbElectricDailyTotals.ReadingDateTime = entity.ReadingDateTime;
                    pbbElectricDailyTotals.HighValue = entity.HighValue;
                    pbbElectricDailyTotals.LowValue = entity.LowValue;
                    pbbElectricDailyTotals.DailySum = entity.DailySum;
                    pbbElectricDailyTotals.DailyAverage = entity.DailyAverage;

                    ctx.Entry(pbbElectricDailyTotals).State = System.Data.Entity.EntityState.Modified;

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
