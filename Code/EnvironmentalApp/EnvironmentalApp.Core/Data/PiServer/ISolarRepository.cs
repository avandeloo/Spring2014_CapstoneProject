using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface ISolarRepository<T>
    {
      
        T GetToday(PiServerTableTags.SolarSources  value);
        T GetByTime(PiServerTableTags.SolarSources value, string time);
        List<T> GetByTime(PiServerTableTags.SolarSources value, string startDateTime, string endDateTime, string timeStep = "1h");
        
     }
}
