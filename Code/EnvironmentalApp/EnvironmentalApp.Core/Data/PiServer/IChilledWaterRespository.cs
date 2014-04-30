using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IChilledWaterRespository<T> 
    {
        T GetToday(PiServerTableTags.ChilledWaterSources value);
        T GetByTime(PiServerTableTags.ChilledWaterSources value, string time);
        List<T> GetByTime(PiServerTableTags.ChilledWaterSources value, string startDateTime, string endDateTime, string timeStep = "1h");
  
    }
}
