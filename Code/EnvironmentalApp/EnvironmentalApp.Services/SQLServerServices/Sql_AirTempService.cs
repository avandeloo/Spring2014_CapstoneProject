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
    public class Sql_AirTempService : Base_SQL_Repository
    {
        ISQLServerBaseRepository<AirTemp_SQL_Repository> airRepo = null;
        ISQLServerBase_DailySumRepository<AirTemp_DailyTotals_SQL_Repository, AirTemp> airRepoDailyTotals = null;

        public Sql_AirTempService()
        {
            airRepo = new AirTemp_SQL_Repository();
            airRepoDailyTotals = new AirTemp_DailyTotals_SQL_Repository();
        }

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

        public int Create_AirTemp_DailyTotals(List<Core.Models.AirTemp> entityList)
        {
            var ctx = new EnergyDataContext(ConnString);
            var dailyTotals = new AirTempDailyTotals();
            var readings = (List<decimal>)entityList.Select(x => x.Reading).ToList();

            dailyTotals.Id = Guid.NewGuid();
            dailyTotals.ReadingDateTime = DateTime.Now;
            dailyTotals.DailySum = SumReadings(readings);
            dailyTotals.DailyAverage = AverageReadings(readings);
            dailyTotals.HighValue = MaxReading(readings);
            dailyTotals.LowValue = MinReading(readings);

            ctx.AIR_TEMP_SUM_BY_DAY.Add(dailyTotals);
   
        }

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

    }
}
