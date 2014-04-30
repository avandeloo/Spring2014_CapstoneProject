using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Data.PiServer;
using EnvironmentalApp.Core.Data.PiServer;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Services.PiServerServices
{
    public class Pi_SolarRadiationService
    {
        SolarRadiation_PI_Repository solarRadRepo = null;
        public Pi_SolarRadiationService()
        {
            solarRadRepo = new SolarRadiation_PI_Repository();
        }
        public Core.Models.SolarRadiation Get_SolarRadiation_ByTime(SolarRadiationSources source, string dateTime="today")
        {
            var solarRad = new Core.Models.SolarRadiation();
            if (dateTime.ToLower() == "today")
            {
                solarRad = solarRadRepo.GetToday(source);
            }
            else {
                solarRad = solarRadRepo.GetByTime(source, dateTime);
            }
            return solarRad;
        }
        public List<Core.Models.SolarRadiation> Get_SolarRadiation_ByTime(SolarRadiationSources source, string startDateTime, string endDateTime, string timeStep = "1h")
        {
            return solarRadRepo.GetByTime(source, startDateTime, endDateTime,timeStep);
        }
    }
}
