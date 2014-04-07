using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class AirTempRepository : BaseRepository, Core.Data.SQLServer.IAirTempRepository
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


        public int Update(AirTemp entity)
        {
            throw new NotImplementedException();
        }
    }
}
