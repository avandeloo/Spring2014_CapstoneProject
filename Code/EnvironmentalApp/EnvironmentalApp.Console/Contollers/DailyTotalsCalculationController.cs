using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Services.SQLServerServices;

namespace EnvironmentalApp.ConsoleApp.Contollers
{
    public class DailyTotalsCalculationController
    {
        DateTime start, end;
        public DailyTotalsCalculationController()
        {
            start = Convert.ToDateTime(String.Format("{0} 00:00:00", DateTime.Now.ToShortDateString()));
            end = Convert.ToDateTime(String.Format("{0} 23:59:59", DateTime.Now.ToShortDateString()));
        }

        public void setCalculatreDate(DateTime date)
        {
            start = Convert.ToDateTime(String.Format("{0} 00:00:00", date.ToShortDateString()));
            end = Convert.ToDateTime(String.Format("{0} 23:59:59", date.ToShortDateString()));

        }

        public int CalculateDailyTotals_AirTemp()
        {
            var sqlService = new Sql_AirTempService();
            return sqlService.Create_AirTemp_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_ChilledWater()
        {
            var sqlService = new Sql_ChilledWaterService();
            return sqlService.Create_ChilledWater_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_ChilledWaterCampus()
        {
            var sqlService = new Sql_ChilledWaterService();
            return sqlService.Create_ChilledWaterCampus_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_Electric()
        {
            var sqlService = new Sql_ElectricService();
            return sqlService.Create_Electric_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_ElectricCampus()
        {
            var sqlService = new Sql_ElectricService();
            return sqlService.Create_ElectricCampus_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_Humidity()
        {
            var sqlService = new Sql_HumidityService();
            return sqlService.Create_Humidity_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_SolarRadiation()
        {
            var sqlService = new Sql_SolarRadiationService();
            return sqlService.Create_SolarRadiation_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_SolarBusBarn()
        {
            var sqlService = new Sql_SolarService();
            return sqlService.Create_SolarBusBarn_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_SolarCarCharger()
        {
            var sqlService = new Sql_SolarService();
            return sqlService.Create_SolarCarCharger_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_Steam()
        {
            var sqlService = new Sql_SteamService();
            return sqlService.Create_Steam_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_SteamCampus()
        {
            var sqlService = new Sql_SteamService();
            return sqlService.Create_SteamCampus_DailyTotals(start, end);
        }
        public int CalculateDailyTotals_Wind()
        {
            var sqlService = new Sql_WindService();
            return sqlService.Create_Wind_DailyTotals(start, end);
        }
    }
}
