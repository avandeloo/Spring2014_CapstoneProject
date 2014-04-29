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
    public class Sql_SolarRadiationService
    {
        ISQLServerBaseRepository<SolarRadiation> solarRadiationRepo = null;
        ISQLServerBase_DailySumRepository<SolarRadiationDailyTotals, SolarRadiation> solarRadiationDailyTotals = null;

        public Sql_SolarRadiationService()
        {
            solarRadiationRepo = new SolarRadiation_SQL_Repository();
            solarRadiationDailyTotals = new SolarRadiation_DailyTotals_SQL_Repository();
        }

        // Solar Radiation

        public Core.Models.SolarRadiation Get_SolarRadiation_ByTime(DateTime dateTime)
        {
            Core.Models.SolarRadiation result = null;
            if(dateTime==DateTime.Today){
             result = solarRadiationRepo.Get(DateTime.Today);
        }else{
            result = solarRadiationRepo.Get(dateTime);
            }
            return result;
        }

        public List<Core.Models.SolarRadiation> Get_SolarRadiation_ByTime(DateTime startDate, DateTime endDate)
        {
            var solarRadiationList = new List<Core.Models.SolarRadiation>();
            solarRadiationList = solarRadiationRepo.Get(startDate, endDate);
            return solarRadiationList;
        }

        public int Create_SolarRadiation_Record(SolarRadiation entity)
        {
            return solarRadiationRepo.Create(entity);
        }

        public int Create_SolarRadiation_List_Of_Records(List<Core.Models.SolarRadiation> entityList)
        {
            return solarRadiationRepo.Create(entityList);
        }

        // Solar Radiation Daily Totals

        public Core.Models.SolarRadiationDailyTotals Get_SolarRadiationDailyTotals_ByTime(DateTime dateTime)
        {
            Core.Models.SolarRadiationDailyTotals result = null;
          
            result = solarRadiationDailyTotals.Get(dateTime);
            return result;
        }

        public List<Core.Models.SolarRadiationDailyTotals> Get_SolarRadiationDailyTotals_ByTime(DateTime startDate, DateTime endDate)
        {
            var solarRadiationDailyTotalsList = new List<Core.Models.SolarRadiationDailyTotals>();
            solarRadiationDailyTotalsList = solarRadiationDailyTotals.Get(startDate, endDate);
            return solarRadiationDailyTotalsList;
        }

        public int Create_SolarRadiation_DailyTotals(DateTime startDate, DateTime endDate)
        {
            // get daily range from SQL server
            var solarRadiationDailyTotalsList = Get_SolarRadiation_ByTime(startDate, endDate);
            // insert/create list into Create daily totals server method
            return solarRadiationDailyTotals.Create(solarRadiationDailyTotalsList);
        }

    }
}
