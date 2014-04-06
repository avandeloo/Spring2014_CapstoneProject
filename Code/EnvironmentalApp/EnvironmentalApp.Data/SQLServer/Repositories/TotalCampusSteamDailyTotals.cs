using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class TotalCampusSteamDailyTotals:BaseRepository, Core.Data.SQLServer.ISteamRepository
    {
        public int Create(Core.Models.SteamDailyTotals entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.TC_STEAM_SUM_BY_DAY.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.SteamDailyTotals> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusSteamDailyTotalsList = new List<SteamDailyTotals>();
                    for (int i = 0; i < totalCampusSteamDailyTotalsList.Count; i++)
                    {
                        ctx.TC_STEAM_SUM_BY_DAY.Add(totalCampusSteamDailyTotalsList[i]);
                        
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
        
        public int Update(Core.Models.SteamDailyTotals entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusSteamDailyTotals = ctx.TC_STEAM_SUM_BY_DAY.FirstOrDefault(x => x.Id == entity.Id);
                    if (totalCampusSteamDailyTotals == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    totalCampusSteamDailyTotals.Id = entity.Id;
                    totalCampusSteamDailyTotals.ReadingDateTime = entity.ReadingDateTime;
                    totalCampusSteamDailyTotals.HighValue = entity.HighValue;
                    totalCampusSteamDailyTotals.LowValue = entity.LowValue;
                    totalCampusSteamDailyTotals.DailySum = entity.DailySum;
                    totalCampusSteamDailyTotals.DailyAverage = entity.DailyAverage;

                    ctx.Entry(totalCampusSteamDailyTotals).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.SteamDailyTotals Get(DateTime dateTime)
        {
            var totalCampusSteamDailyTotals = new SteamDailyTotals();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusSteamDailyTotals = ctx.TC_STEAM_SUM_BY_DAY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return totalCampusSteamDailyTotals;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.SteamDailyTotals> Get(DateTime startTime, DateTime endTime)
        {
            var totalCampusSteamDailyTotalsList = new List<SteamDailyTotals>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    totalCampusSteamDailyTotalsList = ctx.TC_STEAM_SUM_BY_DAY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
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
