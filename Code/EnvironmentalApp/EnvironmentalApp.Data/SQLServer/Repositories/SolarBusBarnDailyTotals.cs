using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class SolarBusBarnDailyTotals:BaseRepository, Core.Data.SQLServer.ISolarRepository
    {
        public int Create(Core.Models.SolarDailyTotals entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.SOLAR_BUS_BARN_SUM_BY_DAY.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.SolarDailyTotals> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarBusBarnDailyTotalsList = new List<SolarDailyTotals>();
                    for (int i = 0; i < solarBusBarnDailyTotalsList.Count; i++)
                    {
                        ctx.SOLAR_BUS_BARN_SUM_BY_DAY.Add(solarBusBarnDailyTotalsList[i]);
                        
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
        
        public int Update(Core.Models.SolarDailyTotals entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarBusBarnDailyTotals = ctx.SOLAR_BUS_BARN_SUM_BY_DAY.FirstOrDefault(x => x.Id == entity.Id);
                    if (solarBusBarnDailyTotals == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    solarBusBarnDailyTotals.Id = entity.Id;
                    solarBusBarnDailyTotals.ReadingDateTime = entity.ReadingDateTime;
                    solarBusBarnDailyTotals.HighValue = entity.HighValue;
                    solarBusBarnDailyTotals.LowValue = entity.LowValue;
                    solarBusBarnDailyTotals.DailySum = entity.DailySum;
                    solarBusBarnDailyTotals.DailyAverage = entity.DailyAverage;

                    ctx.Entry(solarBusBarnDailyTotals).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.SolarDailyTotals Get(DateTime dateTime)
        {
            var solarBusBarnDailyTotals = new SolarDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarBusBarnDailyTotals = ctx.SOLAR_BUS_BARN_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return solarBusBarnDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.SolarDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var solarBusBarnDailyTotalsList = new List<SolarDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarBusBarnDailyTotalsList = ctx.SOLAR_BUS_BARN_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return solarBusBarnDailyTotalsList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
        
    
}
