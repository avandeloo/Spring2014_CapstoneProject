using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface ISolarRadiationRespository
    {
        Core.Models.SolarRadiation GetToday(PiServerTableTags.SolarRadiationSources value);
        Core.Models.SolarRadiation GetByTime(PiServerTableTags.SolarRadiationSources value, string time);
        List<Core.Models.SolarRadiation> GetByTime(PiServerTableTags.SolarRadiationSources value, string startDateTime, string endDateTime, string timeStep = "1h");
   
    }
}
