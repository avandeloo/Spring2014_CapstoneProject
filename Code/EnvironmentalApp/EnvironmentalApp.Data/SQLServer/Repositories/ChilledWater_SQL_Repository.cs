using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class ChilledWater_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.ISQLServerBaseRepository<ChilledWater>
    {

        public int Create(Core.Models.ChilledWater entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.PBB_CHILLED_WATER.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.ChilledWater> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    int result = 0;
                    for (int i = 0; i < entityList.Count; i++)
                    {
                        
                        ctx.PBB_CHILLED_WATER.Add(entityList[i]);
                        result += ctx.SaveChanges();     
                    }
                   
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Update(Core.Models.ChilledWater entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var chilledWater = ctx.PBB_CHILLED_WATER.FirstOrDefault(x => x.Id == entity.Id);
                    if (chilledWater == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    chilledWater.Id = entity.Id;
                    chilledWater.Reading = entity.Reading;
                    chilledWater.ReadingDateTime = entity.ReadingDateTime;
                    chilledWater.Status = entity.Status;
                    chilledWater.TimeStamp = entity.TimeStamp;
                    chilledWater.TimeStep = entity.TimeStep;

                    ctx.Entry(chilledWater).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.ChilledWater Get(DateTime dateTime)
        {
            var chilledWater = new ChilledWater();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    chilledWater = ctx.PBB_CHILLED_WATER.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return chilledWater;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.ChilledWater> Get(DateTime startTime, DateTime endTime)
        {
            var chilledWaterList = new List<ChilledWater>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    chilledWaterList = ctx.PBB_CHILLED_WATER.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return chilledWaterList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
