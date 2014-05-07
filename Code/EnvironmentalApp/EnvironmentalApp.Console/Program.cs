using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.ConsoleApp.Contollers;
using EnvironmentalApp.ConsoleApp;
using System.Timers;
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
                if (ConsoleApp.Default.IsInitialTransfer)
                {
                    Console.WriteLine("Default Import Start Date is: " + ConsoleApp.Default.StartDate);
                    Console.WriteLine("Do you want to change? Y/N");
                    var toChange =Console.ReadLine().ToUpper();
                    if ( toChange== "Y" || toChange== "YES")
                    {
                        InitialTransferSetup();
                    }
                  
                    RunInitialTransfer();
                    ConsoleApp.Default.IsInitialTransfer = false;
                    ConsoleApp.Default.Save();
                }
                else
                {
                    var startDate = DateTime.Now;
                    Console.WriteLine("Starting Hourly Transfer");
                    dataTransfer.RunHourlyTransfer(startDate);
                    Console.WriteLine("Hourly Transfer Completed");
                    //if mid night run daily totals
                    var midNight = new TimeSpan(00, 10, 00, 00);
                    if (DateTime.Now.TimeOfDay <= midNight)
                    {
                        Console.WriteLine("Starting Daily Totals Calculations");
                        dataTransfer.RunDailyTotalsTransfer(startDate);
                    }
                }
            }
            else
            {
                throw new Exception("Can not connect to sql database");
            }
        }

        private static void RunInitialTransfer()
        {
            Console.WriteLine("Starting intitial transfer");
            //get start date from settings file
            var startDate = ConsoleApp.Default.StartDate;
            var processData = new DataTransferController();



            //foreach day run hourly transfer and daily totals calculation
            while (startDate < DateTime.Now)
            {
                var stopWatch = new System.Diagnostics.Stopwatch();
                
                stopWatch.Start();
               
                //set endtime
                DateTime startTime = startDate.AddHours(1);
               DateTime endDate = startDate.AddDays(1);
                //for each hour in day 
                while (startTime <= endDate)
                {
                    try
                    {
                        processData.RunHourlyTransfer(startTime);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    startTime = startTime.AddHours(1);

                }
                Console.WriteLine("Hourly transfer complete for " + startDate.Date);

                //calculate dailytotals
                processData.RunDailyTotalsTransfer(startDate);
                stopWatch.Stop();
                Console.WriteLine("Daily totals calcualted for " + startDate.Date);
                Console.WriteLine(startDate.Date + " calculations took " + stopWatch.Elapsed.ToString());
                //reduce start date
                startDate = endDate;
            }


            throw new NotImplementedException();
        }

        private static void InitialTransferSetup()
        {
           
                Console.WriteLine("Enter new date and hit ENTER:");
                ConsoleApp.Default.StartDate = Convert.ToDateTime(Console.ReadLine());
                ConsoleApp.Default.Save();
                Console.WriteLine("New Import Start Date is: " + ConsoleApp.Default.StartDate);

           
        }
    }
}
