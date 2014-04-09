using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Solar_BusBarn_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISolarSQLRepository<Solar_BusBarn>
    {

        public int Create(Core.Models.Solar_BusBarn entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.SOLAR_BUS_BARN.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Solar_BusBarn> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarBusBarnList = new List<Solar_BusBarn>();
                    for (int i = 0; i < solarBusBarnList.Count; i++)
                    {
                        ctx.SOLAR_BUS_BARN.Add(solarBusBarnList[i]);

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

        public int Update(Core.Models.Solar_BusBarn entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarBusBarn = ctx.SOLAR_BUS_BARN.FirstOrDefault(x => x.Id == entity.Id);
                    if (solarBusBarn == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    solarBusBarn.Id = entity.Id;
                    solarBusBarn.Reading = entity.Reading;
                    solarBusBarn.ReadingDateTime = entity.ReadingDateTime;
                    solarBusBarn.Status = entity.Status;
                    solarBusBarn.TimeStamp = entity.TimeStamp;
                    solarBusBarn.TimeStep = entity.TimeStep;

                    ctx.Entry(solarBusBarn).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.Solar_BusBarn Get(DateTime dateTime)
        {
            var solarBusBarn = new Solar_BusBarn();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarBusBarn = ctx.SOLAR_BUS_BARN.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return solarBusBarn;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.Solar_BusBarn> Get(DateTime startTime, DateTime endTime)
        {
            var solarBusBarnList = new List<Solar_BusBarn>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarBusBarnList = ctx.SOLAR_BUS_BARN.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return solarBusBarnList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
