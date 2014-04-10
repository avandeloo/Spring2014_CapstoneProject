using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Humidity_SQL_Repository:Base_SQL_Repository,Core.Data.SQLServer.IHumiditySQLRepository
    {
        public int Create(Humidity entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.OUTSIDE_HUMIDITY.Add(entity);
                    int result = ctx.SaveChanges();
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public int Update(Humidity entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var humidity = ctx.OUTSIDE_HUMIDITY.FirstOrDefault(x => x.Id == entity.Id);
                    if (humidity == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    humidity.Id = entity.Id;
                    humidity.Reading = entity.Reading;
                    humidity.ReadingDateTime = entity.ReadingDateTime;
                    humidity.Status = entity.Status;
                    humidity.TimeStamp = entity.TimeStamp;
                    humidity.TimeStep = entity.TimeStep;

                    ctx.Entry(humidity).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Humidity Get(DateTime dateTime)
        {
            var humidity = new Humidity();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    humidity = ctx.OUTSIDE_HUMIDITY.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return humidity;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Humidity> Get(DateTime startTime, DateTime endTime)
        {
            try
            {
                var humidityList = new List<Humidity>();
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    humidityList = ctx.OUTSIDE_HUMIDITY.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return humidityList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
