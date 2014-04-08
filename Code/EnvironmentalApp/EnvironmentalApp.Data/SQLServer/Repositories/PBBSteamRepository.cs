using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;


namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class PBBSteamRepository:BaseRepository, Core.Data.SQLServer.ISteamRepository
    {

        public int Create(Core.Models.Steam entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.PBB_STEAM.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Steam> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var steamList = new List<Steam>();
                    for (int i = 0; i < steamList.Count; i++)
                    {
                        ctx.PBB_STEAM.Add(steamList[i]);

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

        public int Update(Core.Models.Steam entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var steam = ctx.PBB_STEAM.FirstOrDefault(x => x.Id == entity.Id);
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

        public Core.Models.Steam Get(DateTime dateTime)
        {
            var steam = new Steam();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    steam = ctx.PBB_STEAM.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return steam;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.Steam> Get(DateTime startTime, DateTime endTime)
        {
            var steamList = new List<Steam>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    steamList = ctx.PBB_STEAM.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
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
