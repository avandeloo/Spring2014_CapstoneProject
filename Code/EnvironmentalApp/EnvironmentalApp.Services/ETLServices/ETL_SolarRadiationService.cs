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
    public class ETL_SolarRadiationService : ETLBaseService,Core.Services.IServices
    {

        public int TransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlSolarRadiaton = new SQLServerServices.Sql_SolarRadiationService();
            var PiSolarRadiaton = new PiServerServices.Pi_SolarRadiationService();
            var SolarRadiatonList = PiSolarRadiaton.Get_SolarRadiation_ByTime(SolarRadiationSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSolarRadiaton.Create_SolarRadiation_List_Of_Records(SolarRadiatonList);
            return result;
        }




        public int CreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_SolarRadiationService();
            return sqlService.Create_SolarRadiation_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
