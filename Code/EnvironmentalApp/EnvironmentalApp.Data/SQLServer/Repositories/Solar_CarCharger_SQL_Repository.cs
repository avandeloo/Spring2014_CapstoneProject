using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Solar_CarCharger_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISolarSQLRepository<Solar_CarCharger>
    {

        public int Create(Core.Models.Solar_CarCharger entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.SOLAR_CAR_CHARGING.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Solar_CarCharger> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    for (int i = 0; i < entityList.Count; i++)
                    {
                        ctx.SOLAR_CAR_CHARGING.Add(entityList[i]);

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

        public int Update(Core.Models.Solar_CarCharger entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarCarCharging = ctx.SOLAR_CAR_CHARGING.FirstOrDefault(x => x.Id == entity.Id);
                    if (solarCarCharging == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    solarCarCharging.Id = entity.Id;
                    solarCarCharging.Reading = entity.Reading;
                    solarCarCharging.ReadingDateTime = entity.ReadingDateTime;
                    solarCarCharging.Status = entity.Status;
                    solarCarCharging.TimeStamp = entity.TimeStamp;
                    solarCarCharging.TimeStep = entity.TimeStep;

                    ctx.Entry(solarCarCharging).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.Solar_CarCharger Get(DateTime dateTime)
        {
            var solarCarCharging = new Solar_CarCharger();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarCarCharging = ctx.SOLAR_CAR_CHARGING.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return solarCarCharging;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.Solar_CarCharger> Get(DateTime startTime, DateTime endTime)
        {
            var solarCarChargingList = new List<Solar_CarCharger>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarCarChargingList = ctx.SOLAR_CAR_CHARGING.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return solarCarChargingList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
