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
    public class Sql_ElectricService
    {
        ISQLServerBaseRepository<Electric> electricRepo = null;
        ISQLServerBase_DailySumRepository<ElectricDailyTotals, Electric> electricDailyTotals = null;
        ISQLServerBaseRepository<Electric_Campus> electricCampusRepo = null;
        ISQLServerBase_DailySumRepository<ElectricDailyTotals_Campus, Electric_Campus> electricCampusDailyTotals = null;


        public Sql_ElectricService()
        {
            electricRepo = new Electric_SQL_Repository();
            electricDailyTotals = new Electric_DailyTotals_SQL_Repository();
            electricCampusRepo = new Electric_Campus_SQL_Repository();
            electricCampusDailyTotals = new Electric_Campus_DailyTotals_SQL_Repository();
        }

        // Electric

        public Core.Models.Electric Get_Electric_ByTime(DateTime dateTime)
        {
            Core.Models.Electric result = null;
            if(dateTime==DateTime.Today){
             result = electricRepo.Get(DateTime.Today);
        }else{
            result = electricRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Electric> Get_Electric_ByTime(DateTime startDate, DateTime endDate)
        {
            var electricList = new List<Core.Models.Electric>();
            electricList = electricRepo.Get(startDate, endDate);
            return electricList;
        }

        public int Create_Electric_Record(Electric entity)
        {
            return electricRepo.Create(entity);
        }

        public int Create_Electric_List_Of_Records(List<Core.Models.Electric> entityList)
        {
            return electricRepo.Create(entityList);
        }

        // Electric Daily Totals

        public Core.Models.ElectricDailyTotals Get_ElectricDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.ElectricDailyTotals result = null;
            if(dateTime==DateTime.Today){
            result = electricDailyTotals.Get(DateTime.Today);
        }else{
            result = electricDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.ElectricDailyTotals> Get_ElectricDailyTotals_ByTime(DateTime startDate, DateTime endDate)
        {
            var electricList = new List<Core.Models.ElectricDailyTotals>();
            electricList = electricDailyTotals.Get(startDate, endDate);
            return electricList;
        }

        public int Create_Electric_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var electricDailyTotalsList = Get_Electric_ByTime(startDate, endDate);
            // insert/create list into Create daily totals server method
            return electricDailyTotals.Create(electricDailyTotalsList);
        }

        // Electric Campus

        public Core.Models.Electric_Campus Get_ElectricCampus_ByTime(DateTime dateTime)
        {
            Core.Models.Electric_Campus result = null;
            if (dateTime == DateTime.Today)
            {
                result = electricCampusRepo.Get(DateTime.Today);
            }
            else
            {
                result = electricCampusRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Electric_Campus> Get_ElectricCampus_ByTime(DateTime startDate, DateTime endDate)
        {
            var electricCampusList = new List<Core.Models.Electric_Campus>();
            electricCampusList = electricCampusRepo.Get(startDate, endDate);
            return electricCampusList;
        }

        public int Create_ElectricCampus_Record(Electric_Campus entity)
        {
            return electricCampusRepo.Create(entity);
        }

        public int Create_ElectricCampus_List_Of_Records(List<Core.Models.Electric_Campus> entityList)
        {
            return electricCampusRepo.Create(entityList);
        }

        // Electric Campus Daily Totals

        public Core.Models.ElectricDailyTotals_Campus Get_ElectricCampusDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.ElectricDailyTotals_Campus result = null;
            if (dateTime == DateTime.Today)
            {
                result = electricCampusDailyTotals.Get(DateTime.Today);
            }
            else
            {
                result = electricCampusDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.ElectricDailyTotals_Campus> Get_ElectricCampusDailyTotals_ByTime(DateTime startDate, DateTime endDate)
        {
            var electricCampusDailyTotalsList = new List<Core.Models.ElectricDailyTotals_Campus>();
            electricCampusDailyTotalsList = electricCampusDailyTotals.Get(startDate, endDate);
            return electricCampusDailyTotalsList;
        }

        public int Create_ElectricCampus_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var electricCampusDailyTotalsList = Get_ElectricCampus_ByTime(startDate, endDate);
            // insert/create list into Create daily totals server method
            return electricCampusDailyTotals.Create(electricCampusDailyTotalsList);
        }
    }
}
