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
    public class ETL_SolarRadiationService : ETLBaseService
    {

        public int SolarRadiation_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlSolarRadiaton = new SQLServerServices.Sql_SolarRadiationService();
            var PiSolarRadiaton = new PiServerServices.Pi_SolarRadiationService();
            var SolarRadiatonList = PiSolarRadiaton.Get_SolarRadiation_ByDateRange(SolarRadiationSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSolarRadiaton.Create_SolarRadiation_List_Of_Records(SolarRadiatonList);
            return result;
        }


    }
}
