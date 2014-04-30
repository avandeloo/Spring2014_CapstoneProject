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
    public class ETL_ChilledWaterService : ETLBaseService,Core.Services.IServices,Core.Services.ICampusServices
    {
        public int TransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlChilledWater = new SQLServerServices.Sql_ChilledWaterService();
            var PiChilledWater = new PiServerServices.Pi_ChilledWaterService();
            var ChilledWaterList = PiChilledWater.Get_ChilledWater_ByTime(ChilledWaterSources.PBB_ChilledWater, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlChilledWater.Create_ChilledWater_List_Of_Records(ChilledWaterList);
            return result;
        }

        public int CampusTransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlChilledWaterCampus = new SQLServerServices.Sql_ChilledWaterService();
            var PiChilledWaterCampus = new PiServerServices.Pi_ChilledWaterService();
            var ChilledWaterCampusList = PiChilledWaterCampus.Get_ChilledWaterCampus_ByTime(ChilledWaterSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlChilledWaterCampus.Create_ChilledWaterCampus_List_Of_Records(ChilledWaterCampusList);
            return result;
        }



        public int CreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_ChilledWaterService();
            return sqlService.Create_ChilledWater_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }


        public int CampusCreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_ChilledWaterService();
            return sqlService.Create_ChilledWaterCampus_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
