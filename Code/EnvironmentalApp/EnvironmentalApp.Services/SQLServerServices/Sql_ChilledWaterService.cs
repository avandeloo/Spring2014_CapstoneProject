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
    public class Sql_ChilledWaterService
    {
        ISQLServerBaseRepository<ChilledWater> chilledWaterRepo = null;
        ISQLServerBase_DailySumRepository<CW_DailyTotals, ChilledWater> chilledWaterDailyTotals = null;
        ISQLServerBaseRepository<ChilledWater_Campus> chilledWaterCampusRepo = null;
        ISQLServerBase_DailySumRepository<CW_DailyTotals_Campus, ChilledWater_Campus> chilledWaterCampusDailyTotals = null;

        public Sql_ChilledWaterService()
        {
            chilledWaterRepo = new ChilledWater_SQL_Repository();
            chilledWaterDailyTotals = new ChilledWater_DailyTotals_SQL_Repository();
            chilledWaterCampusRepo = new ChilledWater_Campus_SQL_Repository();
            chilledWaterCampusDailyTotals = new ChilledWater_Campus_DailyTotals_SQL_Repository();
        }

        // ChilledWater

        public Core.Models.ChilledWater Get_ChilledWater_ByTime(DateTime dateTime)
        {
            Core.Models.ChilledWater result = null;
            if(dateTime==DateTime.Today){
             result = chilledWaterRepo.Get(DateTime.Today);
        }else{
            result = chilledWaterRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.ChilledWater> Get_ChilledWater_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var chilledWaterList = new List<Core.Models.ChilledWater>();
            chilledWaterList = chilledWaterRepo.Get(startDate, endDate);
            return chilledWaterList;
        }

        public int Create_ChilledWater_Record(ChilledWater entity)
        {
            return chilledWaterRepo.Create(entity);
        }

        public int Create_ChilledWater_List_Of_Records(List<Core.Models.ChilledWater> entityList)
        {
            return chilledWaterRepo.Create(entityList);
        }

        // Chilled Water Daily Totals

        public Core.Models.CW_DailyTotals Get_ChilledWaterDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.CW_DailyTotals result = null;
            if(dateTime==DateTime.Today){
            result = chilledWaterDailyTotals.Get(DateTime.Today);
        }else{
            result = chilledWaterDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.CW_DailyTotals> Get_ChilledWaterDailyTotals_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var airTempList = new List<Core.Models.CW_DailyTotals>();
            airTempList = chilledWaterDailyTotals.Get(startDate, endDate);
            return airTempList;
        }

        public int Create_ChilledWater_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var chilledWaterDailyTotalsList = Get_ChilledWater_ByDateRange(startDate, endDate);
            // insert/create list into Create daily totals server method
            return chilledWaterDailyTotals.Create(chilledWaterDailyTotalsList);
        }

        // Chilled Water Campus

        public Core.Models.ChilledWater_Campus Get_ChilledWaterCampus_ByTime(DateTime dateTime)
        {
            Core.Models.ChilledWater_Campus result = null;
            if (dateTime == DateTime.Today)
            {
                result = chilledWaterCampusRepo.Get(DateTime.Today);
            }
            else
            {
                result = chilledWaterCampusRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.ChilledWater_Campus> Get_ChilledWaterCampus_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var chilledWaterCampusList = new List<Core.Models.ChilledWater_Campus>();
            chilledWaterCampusList = chilledWaterCampusRepo.Get(startDate, endDate);
            return chilledWaterCampusList;
        }

        public int Create_ChilledWaterCampus_Record(ChilledWater_Campus entity)
        {
            return chilledWaterCampusRepo.Create(entity);
        }

        public int Create_ChilledWaterCampus_List_Of_Records(List<Core.Models.ChilledWater_Campus> entityList)
        {
            return chilledWaterCampusRepo.Create(entityList);
        }

        // Chilled Water Campus Daily Totals

        public Core.Models.CW_DailyTotals_Campus Get_ChilledWaterCampusDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.CW_DailyTotals_Campus result = null;
            if (dateTime == DateTime.Today)
            {
                result = chilledWaterCampusDailyTotals.Get(DateTime.Today);
            }
            else
            {
                result = chilledWaterCampusDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.CW_DailyTotals_Campus> Get_ChilledWaterCampusDailyTotals_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var chilledWaterCampusDailyTotalsList = new List<Core.Models.CW_DailyTotals_Campus>();
            chilledWaterCampusDailyTotalsList = chilledWaterCampusDailyTotals.Get(startDate, endDate);
            return chilledWaterCampusDailyTotalsList;
        }

        public int Create_ChilledWaterCampus_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var chilledWaterCampusDailyTotalsList = Get_ChilledWaterCampus_ByDateRange(startDate, endDate);
            // insert/create list into Create daily totals server method
            return chilledWaterCampusDailyTotals.Create(chilledWaterCampusDailyTotalsList);
        }

    }
}
