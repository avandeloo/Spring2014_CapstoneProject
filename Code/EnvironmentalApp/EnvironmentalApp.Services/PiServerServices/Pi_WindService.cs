using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.PiServer;
using EnvironmentalApp.Data.PiServer;
using EnvironmentalApp.Core;

namespace EnvironmentalApp.Services.PiServerServices
{
    public class Pi_WindService
    {
        Wind_PI_Repository windRepo = null;

        public Pi_WindService()
        {
            windRepo = new Wind_PI_Repository();
        }
        /// <summary>
        /// Get air temp by time defaults is today
        /// </summary>
        /// <param name="airTempSource"></param>
        /// <param name="dateTime"></param>
        /// <returns>Airtemp </returns>
        public Core.Models.Wind Get_Wind_ByTime(Core.PiServerTableTags.WindSources windSource, string dateTime="today")
        {
             Core.Models.Wind result = null;
            if(dateTime=="today"){
            result = windRepo.GetToday(windSource);
        }else{
                result = windRepo.GetByTime(windSource,dateTime);
            }
            return result;
        }

        public List<Core.Models.Wind> Get_Wind_ByTime(Core.PiServerTableTags.WindSources windSource, string startDate, string endDate)
        {
            var windList = new List<Core.Models.Wind>();
            windList = windRepo.GetByTime(windSource, startDate, endDate);
            return windList;
        }
    }
}
