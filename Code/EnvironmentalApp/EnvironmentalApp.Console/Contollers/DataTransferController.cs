using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EnvironmentalApp.Services.ETLServices;

namespace EnvironmentalApp.ConsoleApp.Contollers
{
    public class DataTransferController
    {
        HourlyDataTransferController hourlyProcess = null;
        DailyTotalsCalculationController dailyProcess = null;
        public DataTransferController()
        {
            hourlyProcess = new HourlyDataTransferController();
            var midNight = new TimeSpan(00, 10, 00, 00);
            if (DateTime.Now.TimeOfDay <= midNight)
            {
                dailyProcess = new DailyTotalsCalculationController();
            }
        }

        public bool CanConnectToSQLServer()
        {
            Core.Configuration.IConfiguration config = new Data.Configuration();
           
            string connString =config.GetSqlServerConnectionString();

            return config.SqlDatabaseExists(connString);
        }

        public void RunHourlyTransfer()
        {
            var start = DateTime.Now.AddHours(-1);
            var end = DateTime.Now.AddMinutes(-1);
            if (hourlyProcess.DataTransfer_AirTemp(start, end) < 1)
            {
                throw new Exception("Air Temp updated failed");
            }
            if (hourlyProcess.DataTransfer_ChilledWater(start, end) < 1)
            {
                throw new Exception("Chilled Water updated failed");
            }
            if (hourlyProcess.DataTransfer_CampusChilledWater(start, end) < 1)
            {
                throw new Exception("Campus Chilled Water updated failed");
            }
            if (hourlyProcess.DataTransfer_Electric(start, end) < 1)
            {
                throw new Exception("Electric updated failed");
            }
            if (hourlyProcess.DataTransfer_CampusElectric(start, end) < 1)
            {
                throw new Exception("Campus Electric updated failed");
            }
            if (hourlyProcess.DataTransfer_Humidity(start, end) < 1)
            {
                throw new Exception("Humidity updated failed");
            }
            if (hourlyProcess.DataTransfer_SolarBusBarn(start, end) < 1)
            {
                throw new Exception("Solar Bus Barn updated failed");
            }
            if (hourlyProcess.DataTransfer_SolarCarCharger(start, end) < 1)
            {
                throw new Exception("Solar Car Chager updated failed");
            }
            if (hourlyProcess.DataTransfer_SolarRadiation(start, end) < 1)
            {
                throw new Exception("Solar Radiation updated failed");
            }
            if (hourlyProcess.DataTransfer_Steam(start, end) < 1)
            {
                throw new Exception("Steam updated failed");
            }
            if (hourlyProcess.DataTransfer_CampusSteam(start, end) < 1)
            {
                throw new Exception("Campus Steam updated failed");
            }
            if (hourlyProcess.DataTransfer_Wind(start, end) < 1)
            {
                throw new Exception("Wind updated failed");
            }
        }

        public int RunDailyTotalsTransfer()
        {

            int result = 0;

            return result;
        }
        
    }
}
