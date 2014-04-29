using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EnvironmentalApp.Services.ETLServices;

namespace EnvironmentalApp.Console.Contollers
{
    public class DataTransferController
    {
        public bool CanConnectToSQLServer()
        {
            Core.Configuration.IConfiguration config = new Data.Configuration();
           
            string connString =config.GetSqlServerConnectionString();

            return config.SqlDatabaseExists(connString);
        }

        public int RunHourlyTransfer()
        {
            int result = 0;

            return result;
            
        }

        public int RunDailyTotalsTransfer()
        {

            int result = 0;

            return result;
        }
        private int DataTransfer_AirTemp(DateTime startTime,DateTime endTime)
        {
            Core.Services.IServices airTempService = new ETL_AirTempService();
            return airTempService.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
    }
}
