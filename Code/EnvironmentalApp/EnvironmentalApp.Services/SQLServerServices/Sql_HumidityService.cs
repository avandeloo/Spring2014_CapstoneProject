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
    public class Sql_HumidityService
    {
        ISQLServerBaseRepository<Humidity> humidityRepo = null;
        ISQLServerBase_DailySumRepository<HumidityDailyTotals, Humidity> humidityDailyTotals = null;

        public Sql_HumidityService()
        {
            humidityRepo = new Humidity_SQL_Repository();
            humidityDailyTotals = new Humidity_DailyTotals_SQL_Repository();
        }

        // Humidity

        public Core.Models.Humidity Get_Humidity_ByTime(DateTime dateTime)
        {
            Core.Models.Humidity result = null;
            if(dateTime==DateTime.Today){
             result = humidityRepo.Get(DateTime.Today);
        }else{
            result = humidityRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Humidity> Get_Humidity_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var humidityList = new List<Core.Models.Humidity>();
            humidityList = humidityRepo.Get(startDate, endDate);
            return humidityList;
        }

        public int Create_Humidity_Record(Humidity entity)
        {
            return humidityRepo.Create(entity);
        }

        public int Create_Humidity_List_Of_Records(List<Core.Models.Humidity> entityList)
        {
            return humidityRepo.Create(entityList);
        }

        // Humidity Daily Totals

        public Core.Models.HumidityDailyTotals Get_HumidityDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.HumidityDailyTotals result = null;
            if(dateTime==DateTime.Today){
            result = humidityDailyTotals.Get(DateTime.Today);
        }else{
            result = humidityDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.HumidityDailyTotals> Get_HumidityDailyTotals_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var humidityList = new List<Core.Models.HumidityDailyTotals>();
            humidityList = humidityDailyTotals.Get(startDate, endDate);
            return humidityList;
        }

        public int Create_Humidity_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var humidityDailyTotalsList = Get_Humidity_ByDateRange(startDate, endDate);
            // insert/create list into Create daily totals server method
            return humidityDailyTotals.Create(humidityDailyTotalsList);
        }

    }
}
