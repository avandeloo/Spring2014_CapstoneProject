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
    public class Sql_WindService
    {
        ISQLServerBaseRepository<Wind> windRepo = null;
        ISQLServerBase_DailySumRepository<WindDailyTotals, Wind> windRepoDailyTotals = null;

        public Sql_WindService()
        {
            windRepo = new Wind_SQL_Repository();
            windRepoDailyTotals = new Wind_DailyTotals_SQL_Repository();
        }

        // Wind

        public Core.Models.Wind Get_Wind_ByTime(DateTime dateTime)
        {
            Core.Models.Wind result = null;
           
            result = windRepo.Get(dateTime);
          
            return result;
        }

        public List<Core.Models.Wind> Get_Wind_ByTime(DateTime startDate, DateTime endDate)
        {
            var windList = new List<Core.Models.Wind>();
            windList = windRepo.Get(startDate, endDate);
            return windList;
        }

        public int Create_Wind_Record(Wind entity)
        {
            return windRepo.Create(entity);
        }

        public int Create_Wind_List_Of_Records(List<Core.Models.Wind> entityList)
        {
            return windRepo.Create(entityList);
        }

        // Wind Daily Totals

        public Core.Models.WindDailyTotals Get_WindDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.WindDailyTotals result = null;
            if(dateTime==DateTime.Today){
            result = windRepoDailyTotals.Get(DateTime.Today);
        }else{
                result = windRepoDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.WindDailyTotals> Get_WindDailyTotals_ByTime(DateTime startDate, DateTime endDate)
        {
            var windDailyTotalsList = new List<Core.Models.WindDailyTotals>();
            windDailyTotalsList = windRepoDailyTotals.Get(startDate, endDate);
            return windDailyTotalsList;
        }

        public int Create_Wind_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var windDailyTotalsList = Get_Wind_ByTime(startDate, endDate);
            // insert/create list into Create daily totals server method
            return windRepoDailyTotals.Create(windDailyTotalsList);
        }


    }
}
