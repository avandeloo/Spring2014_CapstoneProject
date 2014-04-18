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
    public class ETL_ElectricService : ETLBaseService
    {
        public int Electric_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlElectric = new SQLServerServices.Sql_ElectricService();
            var PiElectric = new PiServerServices.Pi_ElectricService();
            var ElectricList = PiElectric.Get_Electric_ByDateRange(ElectricSources.PBB_Electric, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlElectric.Create_Electric_List_Of_Records(ElectricList);
            return result;
        }

        public int ElectricCampus_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlElectricCampus = new SQLServerServices.Sql_ElectricService();
            var PiElectricCampus = new PiServerServices.Pi_ElectricService();
            var ElectricCampusList = PiElectricCampus.Get_ElectricCampus_ByDateRange(ElectricSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlElectricCampus.Create_ElectricCampus_List_Of_Records(ElectricCampusList);
            return result;
        }

    }
}
