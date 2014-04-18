using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Wind_SQL_Repository : Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBaseRepository<Wind>
    {

        public Wind Get(DateTime dateTime)
        {
            var wind = new Wind();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    wind = ctx.WIND.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return wind;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Wind> Get(DateTime startTime, DateTime endTime)
        {
            var windList = new List<Wind>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    windList = ctx.WIND.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return windList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public int Create(Wind entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.WIND.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Wind> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    for (int i = 0; i < entityList.Count; i++)
                    {
                        ctx.WIND.Add(entityList[i]);

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


        public int Update(Wind entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var wind = ctx.WIND.FirstOrDefault(x => x.Id == entity.Id);
                    if (wind == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    wind.Id = entity.Id;
                    wind.Reading = entity.Reading;
                    wind.ReadingDateTime = entity.ReadingDateTime;
                    wind.Status = entity.Status;
                    wind.TimeStamp = entity.TimeStamp;
                    wind.TimeStep = entity.TimeStep;

                    ctx.Entry(wind).State = System.Data.Entity.EntityState.Modified;

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
