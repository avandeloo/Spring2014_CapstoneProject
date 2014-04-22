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
    public class ETL_AirTempService: ETLBaseService
    {

        public int AirTemp_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlAirTemp = new SQLServerServices.Sql_AirTempService();
            var PiAirTemp = new PiServerServices.Pi_AirTempService();
            var airTempList = PiAirTemp.Get_AirTemp_ByDateRange(AirTempSource.OutsideTemp, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlAirTemp.Create_AirTemp_List_Of_Records(airTempList);
            return result;
        }


    }
}
