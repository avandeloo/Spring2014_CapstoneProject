using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class TotalCampusElectricDailyTotals:BaseRepository, Core.Data.SQLServer.IElectricRepository
    {
        public int Create(Core.Models.ElectricDailyTotals entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.TC_ELECTRICITY_SUM_BY_DAY.Add(entity);
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
        
        public int Update(Core.Models.ElectricDailyTotals entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusElectricDailyTotals = ctx.TC_ELECTRICITY_SUM_BY_DAY.FirstOrDefault(x => x.Id == entity.Id);
                    if (totalCampusElectricDailyTotals == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    totalCampusElectricDailyTotals.Id = entity.Id;
                    totalCampusElectricDailyTotals.ReadingDateTime = entity.ReadingDateTime;
                    totalCampusElectricDailyTotals.HighValue = entity.HighValue;
                    totalCampusElectricDailyTotals.LowValue = entity.LowValue;
                    totalCampusElectricDailyTotals.DailySum = entity.DailySum;
                    totalCampusElectricDailyTotals.DailyAverage = entity.DailyAverage;

                    ctx.Entry(totalCampusElectricDailyTotals).State = System.Data.Entity.EntityState.Modified;

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
