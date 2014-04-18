using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Services.ETLServices
{
    public class ETLBaseService
    {
        public static string DateTime_To_PiDateTime(DateTime dateTime)
        {
            var stringDateTime = dateTime.ToString("dd-MMM-yy HH:mm:ss");

            return stringDateTime;
        
        }

    }
}
