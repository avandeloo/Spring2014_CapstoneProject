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
    public class Pi_HumidityService
    {
        Humidity_PI_Repository humRepo = null;
        public Pi_HumidityService()
        {
            humRepo = new Humidity_PI_Repository();
        }
        public Core.Models.Humidity Get_Humidity_ByTime(HumiditySources source, string dateTime="today")
        {
            var humidity = new Core.Models.Humidity();
            if (dateTime.ToLower() == "today")
            {
                humidity = humRepo.GetToday(source);
            }
            else {
                humidity = humRepo.GetByTime(source, dateTime);
            }
            return humidity;
        }
        public List<Core.Models.Humidity> Get_Humidity_ByDateRange(HumiditySources source, string startDateTime, string endDateTime)
        {
            return humRepo.GetByTime(source, startDateTime, endDateTime);
        }
    }
}
