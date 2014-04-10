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
    public class Pi_SolarService
    {
        ISolarRepository<Core.Models.Solar_CarCharger> Solar_CarCharger_Repo = null;
        ISolarRepository<Core.Models.Solar_BusBarn> Solar_BusBarn_Repo = null;
        public Pi_SolarService()
        {
            Solar_CarCharger_Repo = new Solar_CarCharger_PI_Repository();
            Solar_BusBarn_Repo = new Solar_BusBarn_PI_Repository();
        }
        public Core.Models.Solar_CarCharger Get_Solar_ByTime(SolarSources source, string dateTime="today")
        {
            var solar = new Core.Models.Solar_CarCharger();
            if (dateTime.ToLower() == "today")
            {
                solar = Solar_CarCharger_Repo.GetToday(source);
            }
            else {
                solar = Solar_CarCharger_Repo.GetByTime(source, dateTime);
            }
            return solar;
        }
        public List<Core.Models.Solar_CarCharger> Get_Solar_ByDateRange(SolarSources source, string startDateTime, string endDateTime)
        {
            return Solar_CarCharger_Repo.GetByTime(source, startDateTime, endDateTime);
        }
    }
}
