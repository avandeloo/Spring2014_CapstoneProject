using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class ChilledWater_Campus_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.IChilledWaterSQLRepository<ChilledWater_Campus>
    {

        public int Create(Core.Models.ChilledWater_Campus entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.TOTAL_CAMPUS_CHILLED_WATER.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.ChilledWater_Campus> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {

                    for (int i = 0; i < entityList.Count; i++)
                    {
                        ctx.TOTAL_CAMPUS_CHILLED_WATER.Add(entityList[i]);

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

        public int Update(Core.Models.ChilledWater_Campus entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var chilledWater = ctx.TOTAL_CAMPUS_CHILLED_WATER.FirstOrDefault(x => x.Id == entity.Id);
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

        public Core.Models.ChilledWater_Campus Get(DateTime dateTime)
        {
            var chilledWater = new ChilledWater_Campus();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    chilledWater = ctx.TOTAL_CAMPUS_CHILLED_WATER.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return chilledWater;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.ChilledWater_Campus> Get(DateTime startTime, DateTime endTime)
        {
            var chilledWaterList = new List<ChilledWater_Campus>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    chilledWaterList = ctx.TOTAL_CAMPUS_CHILLED_WATER.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
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
