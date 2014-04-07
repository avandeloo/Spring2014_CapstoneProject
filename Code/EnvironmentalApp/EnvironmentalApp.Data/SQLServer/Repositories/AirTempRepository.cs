using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class AirTempRepository:BaseRepository,Core.Data.SQLServer.ISQLServerBaseRepository<AirTemp>
    {
        public int Create(AirTemp entity)
        {
            throw new NotImplementedException();
        }

        public int Create(List<AirTemp> entityList)
        {
            throw new NotImplementedException();
        }

        public int Update(AirTemp entity)
        {
            throw new NotImplementedException();
        }

        public AirTemp Get(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<AirTemp> Get(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }
    }
}
