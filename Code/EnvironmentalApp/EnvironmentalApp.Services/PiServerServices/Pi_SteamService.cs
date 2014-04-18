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
        ISteamRepository<Core.Models.Steam> steamRepo = null;
        ISteamRepository<Core.Models.Steam_Campus> steam_Campus_Repo = null;
        public Pi_SteamService()
        {
            steamRepo = new Steam_PI_Repository();
            steam_Campus_Repo = new Steam_Campus_PI_Repository();
        }

        // Steam

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

        // Steam Campus
        
        public Core.Models.Steam_Campus Get_SteamCampus_ByTime(SteamSources source, string dateTime = "today")
        {
            var steamCampus = new Core.Models.Steam_Campus();
            if (dateTime.ToLower() == "today")
            {
                steamCampus = steam_Campus_Repo.GetToday(source);
            }
            else
            {
                steamCampus = steam_Campus_Repo.GetByTime(source, dateTime);
            }
            return steamCampus;
        }
        public List<Core.Models.Steam_Campus> Get_SteamCampus_ByDateRange(SteamSources source, string startDateTime, string endDateTime)
        {
            return steam_Campus_Repo.GetByTime(source, startDateTime, endDateTime);
        }

    }
}
