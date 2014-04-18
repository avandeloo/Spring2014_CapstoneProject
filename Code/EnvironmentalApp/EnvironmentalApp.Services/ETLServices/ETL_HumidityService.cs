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
    public class ETL_HumidityService : ETLBaseService
    {

        public int Humidity_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlHumidity = new SQLServerServices.Sql_HumidityService();
            var PiHumidity = new PiServerServices.Pi_HumidityService();
            var HumidityList = PiHumidity.Get_Humidity_ByDateRange(HumiditySources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlHumidity.Create_Humidity_List_Of_Records(HumidityList);
            return result;
        }


    }
}
