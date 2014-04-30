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
    public class ETL_HumidityService : ETLBaseService,Core.Services.IServices
    {

        public int TransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlHumidity = new SQLServerServices.Sql_HumidityService();
            var PiHumidity = new PiServerServices.Pi_HumidityService();
            var HumidityList = PiHumidity.Get_Humidity_ByTime(HumiditySources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlHumidity.Create_Humidity_List_Of_Records(HumidityList);
            return result;
        }




        public int CreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_HumidityService();
            return sqlService.Create_Humidity_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
