using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class SolarRadiation_SQL_Repository : Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBaseRepository<SolarRadiation>
    {

        public int Create(Core.Models.SolarRadiation entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.SOLAR_RADIATION.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.SolarRadiation> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    for (int i = 0; i < entityList.Count; i++)
                    {
                        ctx.SOLAR_RADIATION.Add(entityList[i]);

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

        public int Update(Core.Models.SolarRadiation entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var solarRadiation = ctx.SOLAR_CAR_CHARGING.FirstOrDefault(x => x.Id == entity.Id);
                    if (solarRadiation == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    solarRadiation.Id = entity.Id;
                    solarRadiation.Reading = entity.Reading;
                    solarRadiation.ReadingDateTime = entity.ReadingDateTime;
                    solarRadiation.Status = entity.Status;
                    solarRadiation.TimeStamp = entity.TimeStamp;
                    solarRadiation.TimeStep = entity.TimeStep;

                    ctx.Entry(solarRadiation).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.SolarRadiation Get(DateTime dateTime)
        {
            var solarRadiation = new SolarRadiation();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarRadiation = ctx.SOLAR_RADIATION.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return solarRadiation;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.SolarRadiation> Get(DateTime startTime, DateTime endTime)
        {
            var solarRadiationList = new List<SolarRadiation>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    solarRadiationList = ctx.SOLAR_RADIATION.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return solarRadiationList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
