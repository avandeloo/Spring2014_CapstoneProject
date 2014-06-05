using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Configuration;
using EnvironmentalApp.Data;
namespace EnvironmentalApp.Services
{
    public class ConfigurationServices
    {
        IConfiguration config = new Configuration();

        public bool CanConnectToPi()
        {
            var connString = config.GetPiServerConnectionString();
            return config.PiConnectionExists(connString);  
        }
        public bool CanConnectToSql()
        {
           var connString =config.GetSqlServerConnectionString();
            return config.SqlDatabaseExists(connString);

        }
    }
}
