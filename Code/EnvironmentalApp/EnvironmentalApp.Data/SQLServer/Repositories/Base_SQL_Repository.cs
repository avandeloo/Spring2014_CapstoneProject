using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Base_SQL_Repository
    {
        internal string ConnString = ""; 
        public Base_SQL_Repository()
        { 
            var config =new Configuration();
            ConnString = config.GetSqlServerConnectionString();
        }
        internal static float SumReadings(List<float> readings)
        {

            return readings.Sum();
        }
        internal static float AverageReadings(List<float> readings)
        {
            return readings.Average();
        }
        internal static float MinReading(List<float> readings)
        {
            return readings.Min();
        }
        internal static float MaxReading(List<float> readings)
        {
            return readings.Max();
        }
    }
}
