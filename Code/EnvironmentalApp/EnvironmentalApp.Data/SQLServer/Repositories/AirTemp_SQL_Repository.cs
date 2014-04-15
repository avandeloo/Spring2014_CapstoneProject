using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class AirTemp_SQL_Repository : Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBaseRepository<AirTemp>
    {

        public AirTemp Get(DateTime dateTime)
        {
            var airTemp = new AirTemp();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    airTemp = ctx.OUTSIDE_AIR_TEMP.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return airTemp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AirTemp> Get(DateTime startTime, DateTime endTime)
        {
            var airTempList = new List<AirTemp>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    airTempList = ctx.OUTSIDE_AIR_TEMP.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return airTempList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public int Create(AirTemp entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.OUTSIDE_AIR_TEMP.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.AirTemp> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    for (int i = 0; i < entityList.Count; i++)
                    {
                        ctx.OUTSIDE_AIR_TEMP.Add(entityList[i]);

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


        public int Update(AirTemp entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var airTemp = ctx.OUTSIDE_AIR_TEMP.FirstOrDefault(x => x.Id == entity.Id);
                    if (airTemp == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    airTemp.Id = entity.Id;
                    airTemp.Reading = entity.Reading;
                    airTemp.ReadingDateTime = entity.ReadingDateTime;
                    airTemp.Status = entity.Status;
                    airTemp.TimeStamp = entity.TimeStamp;
                    airTemp.TimeStep = entity.TimeStep;

                    ctx.Entry(airTemp).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
