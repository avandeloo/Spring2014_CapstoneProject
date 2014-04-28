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
    public class Sql_SolarService
    {
        ISQLServerBaseRepository<Solar_CarCharger> solarCarChargerRepo = null;
        ISQLServerBase_DailySumRepository<SolarDailyTotals_CarCharger, Solar_CarCharger> solarCarChargerDailyTotals = null;
        ISQLServerBaseRepository<Solar_BusBarn> solarBusBarnRepo = null;
        ISQLServerBase_DailySumRepository<SolarDailyTotals_BusBarn, Solar_BusBarn> solarBusBarnDailyTotals = null;

        public Sql_SolarService()
        {
            solarCarChargerRepo = new Solar_CarCharger_SQL_Repository();
            solarCarChargerDailyTotals = new Solar_CarCharger_DailyTotals_SQL_Repository();
            solarBusBarnRepo = new Solar_BusBarn_SQL_Repository();
            solarBusBarnDailyTotals = new Solar_BusBarn_DailyTotals_SQL_Repository();
        }

        // Solar Car Charging

        public Core.Models.Solar_CarCharger Get_SolarCarCharger_ByTime(DateTime dateTime)
        {
            Core.Models.Solar_CarCharger result = null;
            if(dateTime==DateTime.Today){
            result = solarCarChargerRepo.Get(DateTime.Today);
        }else{
            result = solarCarChargerRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Solar_CarCharger> Get_SolarCarCharger_ByTime(DateTime startDate, DateTime endDate)
        {
            var solarCarChargerList = new List<Core.Models.Solar_CarCharger>();
            solarCarChargerList = solarCarChargerRepo.Get(startDate, endDate);
            return solarCarChargerList;
        }

        public int Create_SolarCarCharger_Record(Solar_CarCharger entity)
        {
            return solarCarChargerRepo.Create(entity);
        }

        public int Create_SolarCarCharger_List_Of_Records(List<Core.Models.Solar_CarCharger> entityList)
        {
            return solarCarChargerRepo.Create(entityList);
        }

        // Solar Car Charger Daily Totals

        public Core.Models.SolarDailyTotals_CarCharger Get_SolarCarChargerDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.SolarDailyTotals_CarCharger result = null;
            if(dateTime==DateTime.Today){
            result = solarCarChargerDailyTotals.Get(DateTime.Today);
        }else{
            result = solarCarChargerDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.SolarDailyTotals_CarCharger> Get_SolarCarChargerDailyTotals_ByTime(DateTime startDate, DateTime endDate)
        {
            var solarCarChargerList = new List<Core.Models.SolarDailyTotals_CarCharger>();
            solarCarChargerList = solarCarChargerDailyTotals.Get(startDate, endDate);
            return solarCarChargerList;
        }

        public int Create_SolarCarCharger_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var solarCarChargerDailyTotalsList = Get_SolarCarCharger_ByTime(startDate, endDate);
            // insert/create list into Create daily totals server method
            return solarCarChargerDailyTotals.Create(solarCarChargerDailyTotalsList);
        }

        // Solar Bus Barn

        public Core.Models.Solar_BusBarn Get_SolarBusBarn_ByTime(DateTime dateTime)
        {
            Core.Models.Solar_BusBarn result = null;
            if (dateTime == DateTime.Today)
            {
                result = solarBusBarnRepo.Get(DateTime.Today);
            }
            else
            {
                result = solarBusBarnRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.Solar_BusBarn> Get_SolarBusBarn_ByTime(DateTime startDate, DateTime endDate)
        {
            var solarBusBarnList = new List<Core.Models.Solar_BusBarn>();
            solarBusBarnList = solarBusBarnRepo.Get(startDate, endDate);
            return solarBusBarnList;
        }

        public int Create_SolarBusBarn_Record(Solar_BusBarn entity)
        {
            return solarBusBarnRepo.Create(entity);
        }

        public int Create_SolarBusBarn_List_Of_Records(List<Core.Models.Solar_BusBarn> entityList)
        {
            return solarBusBarnRepo.Create(entityList);
        }

        // Solar Bus Barn Daily Totals

        public Core.Models.SolarDailyTotals_BusBarn Get_SolarBusBarnDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.SolarDailyTotals_BusBarn result = null;
            if (dateTime == DateTime.Today)
            {
                result = solarBusBarnDailyTotals.Get(DateTime.Today);
            }
            else
            {
                result = solarBusBarnDailyTotals.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.SolarDailyTotals_BusBarn> Get_SolarBusBarnDailyTotals_ByTime(DateTime startDate, DateTime endDate)
        {
            var solarBusBarnDailyTotalsList = new List<Core.Models.SolarDailyTotals_BusBarn>();
            solarBusBarnDailyTotalsList = solarBusBarnDailyTotals.Get(startDate, endDate);
            return solarBusBarnDailyTotalsList;
        }

        public int Create_SolarBusBarn_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var solarBusBarnDailyTotalsList = Get_SolarBusBarn_ByTime(startDate, endDate);
            // insert/create list into Create daily totals server method
            return solarBusBarnDailyTotals.Create(solarBusBarnDailyTotalsList);
        }
    }
}
