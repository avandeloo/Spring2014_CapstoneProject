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
    public class ETL_SteamService : ETLBaseService,Core.Services.IServices,Core.Services.ICampusServices
    {
        public int TransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlSteam = new SQLServerServices.Sql_SteamService();
            var PiSteam = new PiServerServices.Pi_SteamService();
            var steamList = PiSteam.Get_Steam_ByTime(SteamSources.PBB_Steam, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlSteam.Create_Steam_List_Of_Records(steamList);
            return result;
        }

        public int CampusTransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlSteamCampus = new SQLServerServices.Sql_SteamService();
            var PiSteamCampus = new PiServerServices.Pi_SteamService();
            var steamCampusList = PiSteamCampus.Get_SteamCampus_ByTime(SteamSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlSteamCampus.Create_SteamCampus_List_Of_Records(steamCampusList);
            return result;
        }



        public int CreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_SteamService();
            return sqlService.Create_Steam_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }


        public int CampusCreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_SteamService();
            return sqlService.Create_SteamCampus_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
