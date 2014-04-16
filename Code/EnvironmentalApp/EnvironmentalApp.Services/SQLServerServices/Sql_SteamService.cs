using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.SQLServer;
using EnvironmentalApp.Data.SQLServer.Repositories;
using EnvironmentalApp.Core;
using EnvironmentalApp.Data.SQLServer;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Services.SQLServerServices
{
    public class Sql_SteamService
    {
        ISQLServerBaseRepository<Steam> steamRepo = null;
        ISQLServerBase_DailySumRepository<SteamDailyTotals, Steam> steamDailyTotals = null;
        ISQLServerBaseRepository<Steam_Campus> steamCampusRepo = null;
        ISQLServerBase_DailySumRepository<SteamDailyTotals_Campus, Steam_Campus> steamCampusDailyTotals = null;


        public Sql_SteamService()
        {
            steamRepo = new Steam_SQL_Repository();
            steamDailyTotals = new Steam_DailyTotals_SQL_Repository();
            steamCampusRepo = new Steam_Campus_SQL_Repository();
            steamCampusDailyTotals = new Steam_Campus_DailyTotals_SQL_Repository();
        }

        // Steam

        public Core.Models.Steam Get_Steam_ByTime(DateTime dateTime)
        {
            Core.Models.Steam result = null;
            if(dateTime==DateTime.Today){
            result = steamRepo.Get(DateTime.Today);
        }else{
            result = steamRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Steam> Get_Steam_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var steamList = new List<Core.Models.Steam>();
            steamList = steamRepo.Get(startDate, endDate);
            return steamList;
        }

        public int Create_Steam_Record(Steam entity)
        {
            return steamRepo.Create(entity);
        }

        public int Create_Steam_List_Of_Records(List<Core.Models.Steam> entityList)
        {
            return steamRepo.Create(entityList);
        }

        // Steam Daily Totals

        public Core.Models.SteamDailyTotals Get_SteamDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.SteamDailyTotals result = null;
            if(dateTime==DateTime.Today){
            result = steamDailyTotals.Get(DateTime.Today);
        }else{
            result = steamDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.SteamDailyTotals> Get_SteamDailyTotals_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var steamDailyTotalsList = new List<Core.Models.SteamDailyTotals>();
            steamDailyTotalsList = steamDailyTotals.Get(startDate, endDate);
            return steamDailyTotalsList;
        }

        public int Create_Steam_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var steamDailyTotalsList = Get_Steam_ByDateRange(startDate, endDate);
            // insert/create list into Create daily totals server method
            return steamDailyTotals.Create(steamDailyTotalsList);
        }

        // Steam Campus

        public Core.Models.Steam_Campus Get_SteamCampus_ByTime(DateTime dateTime)
        {
            Core.Models.Steam_Campus result = null;
            if (dateTime == DateTime.Today)
            {
                result = steamCampusRepo.Get(DateTime.Today);
            }
            else
            {
                result = steamCampusRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Steam_Campus> Get_SteamCampus_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var steamCampusList = new List<Core.Models.Steam_Campus>();
            steamCampusList = steamCampusRepo.Get(startDate, endDate);
            return steamCampusList;
        }

        public int Create_SteamCampus_Record(Steam_Campus entity)
        {
            return steamCampusRepo.Create(entity);
        }

        public int Create_SteamCampus_List_Of_Records(List<Core.Models.Steam_Campus> entityList)
        {
            return steamCampusRepo.Create(entityList);
        }

        // Steam Campus Daily Totals

        public Core.Models.SteamDailyTotals_Campus Get_SteamCampusDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.SteamDailyTotals_Campus result = null;
            if (dateTime == DateTime.Today)
            {
                result = steamCampusDailyTotals.Get(DateTime.Today);
            }
            else
            {
                result = steamCampusDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.SteamDailyTotals_Campus> Get_SteamCampusDailyTotals_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var steamCampusDailyTotalsList = new List<Core.Models.SteamDailyTotals_Campus>();
            steamCampusDailyTotalsList = steamCampusDailyTotals.Get(startDate, endDate);
            return steamCampusDailyTotalsList;
        }

        public int Create_SteamCampus_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var steamCampusDailyTotalsList = Get_SteamCampus_ByDateRange(startDate, endDate);
            // insert/create list into Create daily totals server method
            return steamCampusDailyTotals.Create(steamCampusDailyTotalsList);
        }

    }
}
