using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Services;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core;


namespace EnvironmentalApp.Services.ETLServices
{
    public class ETL_SteamService : ETLBaseService
    {
        public int Steam_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlSteam = new SQLServerServices.Sql_SteamService();
            var PiSteam = new PiServerServices.Pi_SteamService();
            var steamList = PiSteam.Get_Steam_ByDateRange(SteamSources.PBB_Steam, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSteam.Create_Steam_List_Of_Records(steamList);
            return result;
        }

        public int SteamCampus_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlSteamCampus = new SQLServerServices.Sql_SteamService();
            var PiSteamCampus = new PiServerServices.Pi_SteamService();
            var steamCampusList = PiSteamCampus.Get_SteamCampus_ByDateRange(SteamSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSteamCampus.Create_SteamCampus_List_Of_Records(steamCampusList);
            return result;
        }

    }
}
