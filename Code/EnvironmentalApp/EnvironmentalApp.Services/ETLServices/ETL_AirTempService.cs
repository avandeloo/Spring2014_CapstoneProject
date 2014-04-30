using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Services;
using EnvironmentalApp.Core.PiServerTableTags;



namespace EnvironmentalApp.Services.ETLServices
{
    public class ETL_AirTempService : ETLBaseService, Core.Services.IServices
    {


        public int TransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlAirTemp = new SQLServerServices.Sql_AirTempService();
            var PiAirTemp = new PiServerServices.Pi_AirTempService();
            var airTempList = PiAirTemp.Get_AirTemp_ByTime(AirTempSource.OutsideTemp, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate),"15m");
            var result = SqlAirTemp.Create_AirTemp_List_Of_Records(airTempList);
            return result;
        }




        public int CreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_AirTempService();
            return sqlService.Create_AirTemp_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
