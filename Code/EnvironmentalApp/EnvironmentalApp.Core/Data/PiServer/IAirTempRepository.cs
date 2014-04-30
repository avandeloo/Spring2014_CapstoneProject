using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IAirTempRepository
    {
        Core.Models.AirTemp GetToday(PiServerTableTags.AirTempSource value);
        Core.Models.AirTemp GetByTime(PiServerTableTags.AirTempSource value, string time);
        List<Core.Models.AirTemp> GetByTime(PiServerTableTags.AirTempSource value, string startDateTime, string endDateTime, string timeStep = "1h");
   
    }
}
