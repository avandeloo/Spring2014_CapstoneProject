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
    public class Pi_SteamService
    {
         IPiServerRepository<Core.Models.Steam, SteamSources> steamRepo = null;
        public Pi_SteamService()
        {
            steamRepo = new SteamRepository();
        }
        public Core.Models.Steam Get_Steam_ByTime(SteamSources source, string dateTime="today")
        {
            var steam = new Core.Models.Steam();
            if (dateTime.ToLower() == "today")
            {
                steam = steamRepo.GetToday(source);
            }
            else {
                steam = steamRepo.GetByTime(source, dateTime);
            }
            return steam;
        }
        public List<Core.Models.Steam> Get_Steam_ByDateRange(SteamSources source, string startDateTime, string endDateTime)
        {
            return steamRepo.GetByTime(source, startDateTime, endDateTime);
        }
    }
}
