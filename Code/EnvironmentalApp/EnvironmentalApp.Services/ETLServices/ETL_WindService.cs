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
    public class ETL_WindService : ETLBaseService
    {
        public int Wind_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlWind = new SQLServerServices.Sql_WindService();
            var PiWind = new PiServerServices.Pi_WindService();
            var windList = PiWind.Get_Wind_ByTime(WindSources.WindTurbine, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlWind.Create_Wind_List_Of_Records(windList);
            return result;
        }

    }
}
