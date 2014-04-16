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
    public class Sql_AirTempService
    {
        ISQLServerBaseRepository<AirTemp> airRepo = null;
        ISQLServerBase_DailySumRepository<AirTempDailyTotals, AirTemp> airRepoDailyTotals = null;

        public Sql_AirTempService()
        {
            airRepo = new AirTemp_SQL_Repository();
            airRepoDailyTotals = new AirTemp_DailyTotals_SQL_Repository();
        }

        // AirTemp

        public Core.Models.AirTemp Get_AirTemp_ByTime(DateTime dateTime)
        {
            Core.Models.AirTemp result = null;
            if(dateTime==DateTime.Today){
            result = airRepo.Get(DateTime.Today);
        }else{
                result = airRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.AirTemp> Get_AirTemp_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var airTempList = new List<Core.Models.AirTemp>();
            airTempList = airRepo.Get(startDate, endDate);
            return airTempList;
        }

        public int Create_AirTemp(AirTemp entity)
        {
            return airRepo.Create(entity);
        }

        public int Create_AirTemp_List(List<Core.Models.AirTemp> entityList)
        {
            return airRepo.Create(entityList);
        }

        // AirTemp Daily Totals

        public Core.Models.AirTempDailyTotals Get_AirTempDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.AirTempDailyTotals result = null;
            if(dateTime==DateTime.Today){
            result = airRepoDailyTotals.Get(DateTime.Today);
        }else{
                result = airRepoDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.AirTempDailyTotals> Get_AirTempDailyTotals_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var airTempList = new List<Core.Models.AirTempDailyTotals>();
            airTempList = airRepoDailyTotals.Get(startDate, endDate);
            return airTempList;
        }

        public int Create_AirTemp_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var airTempDailyTotalsList = Get_AirTemp_ByDateRange(startDate, endDate);
            // insert/create list into Create daily totals server method
            return airRepoDailyTotals.Create(airTempDailyTotalsList);
        }


    }
}
