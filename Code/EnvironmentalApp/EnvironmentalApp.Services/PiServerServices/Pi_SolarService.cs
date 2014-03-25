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
         IPiServerRepository<Core.Models.Solar, SolarSources> Repo = null;
        public Pi_SolarService()
        {
            Repo = new SolarRepository();
        }
        public Core.Models.Solar Get_Solar_ByTime(SolarSources source, string dateTime="today")
        {
            var solar = new Core.Models.Solar();
            if (dateTime.ToLower() == "today")
            {
                solar = Repo.GetToday(source);
            }
            else {
                solar = Repo.GetByTime(source, dateTime);
            }
            return solar;
        }
        public List<Core.Models.Solar> Get_Solar_ByDateRange(SolarSources source, string startDateTime, string endDateTime)
        {
            return Repo.GetByTime(source, startDateTime, endDateTime);
        }
    }
}
