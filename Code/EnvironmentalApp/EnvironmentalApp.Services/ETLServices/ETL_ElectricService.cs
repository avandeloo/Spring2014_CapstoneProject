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
    public class ETL_ElectricService : ETLBaseService,Core.Services.IServices,Core.Services.ICampusServices
    {
        public int TransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlElectric = new SQLServerServices.Sql_ElectricService();
            var PiElectric = new PiServerServices.Pi_ElectricService();
            var ElectricList = PiElectric.Get_Electric_ByTime(ElectricSources.PBB_Electric, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlElectric.Create_Electric_List_Of_Records(ElectricList);
            return result;
        }

        public int CampusTransferPiHourlyToSqlHourly(DateTime startDate, DateTime endDate)
        {
            var SqlElectricCampus = new SQLServerServices.Sql_ElectricService();
            var PiElectricCampus = new PiServerServices.Pi_ElectricService();
            var ElectricCampusList = PiElectricCampus.Get_ElectricCampus_ByTime(ElectricSources.Campus_Total, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate), "15m");
            var result = SqlElectricCampus.Create_ElectricCampus_List_Of_Records(ElectricCampusList);
            return result;
        }



        public int CreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_ElectricService();
            return sqlService.Create_Electric_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }


        public int CampusCreateDailyTotalsValues()
        {
            var sqlService = new SQLServerServices.Sql_ElectricService();
            return sqlService.Create_ElectricCampus_DailyTotals(DateTime.Now.AddMinutes(-1), DateTime.Now.AddDays(-1));
        }
    }
}
