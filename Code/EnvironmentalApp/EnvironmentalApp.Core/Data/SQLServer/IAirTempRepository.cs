using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface IAirTempRepository
    {
        int Create(Core.Models.AirTemp entity);
        int Update(Core.Models.AirTemp entity);
        Core.Models.AirTemp Get(DateTime dateTime);
        List<Core.Models.AirTemp> Get(DateTime startTime, DateTime endTime);
    }
}
