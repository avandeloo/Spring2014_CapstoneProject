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
        internal static decimal SumReadings(List<decimal> readings)
        {

            return readings.Sum();
        }
        internal static decimal AverageReadings(List<decimal> readings)
        {
            return readings.Average();
        }
        internal static decimal MinReading(List<decimal> readings)
        {
            return readings.Min();
        }
        internal static decimal MaxReading(List<decimal> readings)
        {
            return readings.Max();
        }
    }
}
