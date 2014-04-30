using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.ConsoleApp.Contollers;

namespace EnvironmentalApp.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataTransfer = new DataTransferController();
            Console.WriteLine("Starting Transfer");
            if (dataTransfer.CanConnectToSQLServer())
            {
                Console.WriteLine("Starting Hourly Transfer");
                dataTransfer.RunHourlyTransfer();
                Console.WriteLine("Hourly Transfer Completed");
                //if mid night run daily totals
                var midNight=new TimeSpan(00,10,00,00);
                if (DateTime.Now.TimeOfDay <=midNight)
                {
                    Console.WriteLine("Starting Daily Totals Calculations");
                    dataTransfer.RunDailyTotalsTransfer();
                }
            }
            else
            {
                throw new Exception("Can not connect to sql database");
            }
        }
    }
}
