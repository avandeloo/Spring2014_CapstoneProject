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
    public class ETL_SolarService : ETLBaseService
    {
        public int SolarCarChargerTransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlSolarCarCharger = new SQLServerServices.Sql_SolarService();
            var PiSolarCarCharger = new PiServerServices.Pi_SolarService();
            var SolarCarChargerList = PiSolarCarCharger.Get_SolarCarCharger_ByTime(SolarSources.CarPort, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSolarCarCharger.Create_SolarCarCharger_List_Of_Records(SolarCarChargerList);
            return result;
        }

        public int SolarBusBarnTransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlSolarBusBarn = new SQLServerServices.Sql_SolarService();
            var PiSolarBusBarn = new PiServerServices.Pi_SolarService();
            var SolarBusBarnList = PiSolarBusBarn.Get_SolarBusBarn_ByTime(SolarSources.BusBarn, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSolarBusBarn.Create_SolarBusBarn_List_Of_Records(SolarBusBarnList);
            return result;
        }
        public int SolarCarChargerCreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_SolarService();
            return sqlService.Create_SolarCarCharger_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
        public int SolarBusBarnCreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_SolarService();
            return sqlService.Create_SolarBusBarn_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
