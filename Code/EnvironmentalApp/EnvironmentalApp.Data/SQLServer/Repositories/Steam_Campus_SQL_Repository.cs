using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Steam_Campus_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISteamSQLRepository<Steam_Campus>
    {

        public int Create(Core.Models.Steam_Campus entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.TOTAL_CAMPUS_STEAM.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Steam_Campus> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var totalCampusSteamList = new List<Steam_Campus>();
                    for (int i = 0; i < totalCampusSteamList.Count; i++)
                    {
                        ctx.TOTAL_CAMPUS_STEAM.Add(totalCampusSteamList[i]);

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

        public int Update(Core.Models.Steam_Campus entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var steam = ctx.TOTAL_CAMPUS_STEAM.FirstOrDefault(x => x.Id == entity.Id);
                    if (steam == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    steam.Id = entity.Id;
                    steam.Reading = entity.Reading;
                    steam.ReadingDateTime = entity.ReadingDateTime;
                    steam.Status = entity.Status;
                    steam.TimeStamp = entity.TimeStamp;
                    steam.TimeStep = entity.TimeStep;

                    ctx.Entry(steam).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.Steam_Campus Get(DateTime dateTime)
        {
            var steam = new Steam_Campus();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    steam = ctx.TOTAL_CAMPUS_STEAM.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return steam;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.Steam_Campus> Get(DateTime startTime, DateTime endTime)
        {
            var steamList = new List<Steam_Campus>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    steamList = ctx.TOTAL_CAMPUS_STEAM.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return steamList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
