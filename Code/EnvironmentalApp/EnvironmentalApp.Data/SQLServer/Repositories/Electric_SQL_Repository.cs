using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Electric_SQL_Repository:Base_SQL_Repository, Core.Data.SQLServer.IElectricSQLRepository
    {

        public int Create(Core.Models.Electric entity)
        {
            try
            {

                using (var ctx = new EnergyDataContext(ConnString))
                {
                    ctx.PBB_ELECTRIC.Add(entity);
                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Create(List<Core.Models.Electric> entityList)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var electricList = new List<Electric>();
                    for (int i = 0; i < electricList.Count; i++)
                    {
                        ctx.PBB_ELECTRIC.Add(electricList[i]);

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

        public int Update(Core.Models.Electric entity)
        {
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    var electric = ctx.PBB_ELECTRIC.FirstOrDefault(x => x.Id == entity.Id);
                    if (electric == null)
                    {
                        throw new Exception("Record doesn't exist and cannot be updated");
                    }
                    electric.Id = entity.Id;
                    electric.Reading = entity.Reading;
                    electric.ReadingDateTime = entity.ReadingDateTime;
                    electric.Status = entity.Status;
                    electric.TimeStamp = entity.TimeStamp;
                    electric.TimeStep = entity.TimeStep;

                    ctx.Entry(electric).State = System.Data.Entity.EntityState.Modified;

                    int result = ctx.SaveChanges();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Models.Electric Get(DateTime dateTime)
        {
            var electric = new Electric();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    electric = ctx.PBB_ELECTRIC.FirstOrDefault(x => x.ReadingDateTime == dateTime);
                    return electric;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Core.Models.Electric> Get(DateTime startTime, DateTime endTime)
        {
            var electricList = new List<Electric>();
            try
            {
                using (var ctx = new EnergyDataContext(ConnString))
                {
                    electricList = ctx.PBB_ELECTRIC.AsEnumerable().Where(x => x.ReadingDateTime >= startTime && x.ReadingDateTime <= endTime).ToList();
                    return electricList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}
