using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace EnvironmentalApp.Data.PiServer
{
    public abstract class PiServerRepositoryBase
    {
        public OdbcConnection piServer = null;
        public PiServerRepositoryBase()
        {
            Core.Configuration.IConfiguration config = new Configuration();
            piServer = Configuration.GetPiServerConnection(config.GetPiServerConnectionString());
        }


        /// <summary>
        /// Get all records from some table by tag
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="piTableType"></param>
        /// <param name="tag"></param>
        /// <returns>select command as string</returns>
        protected string SelectCommand(string fields, string piTableType, string tag)
        {
            var selectCmd = String.Format("Select {0} From {1} WHERE tag = '{2}'", fields, piTableType, tag);

            return selectCmd;
        }
        /// <summary>
        /// Get a record from some table by tag and time
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="piTableType"></param>
        /// <param name="tag"></param>
        /// <param name="timeFilter"></param>
        /// <returns>select command as string</returns>
        protected string SelectCommand(string fields, string piTableType, string tag, string timeFilter)
        {
            var selectCmd = String.Format("Select {0} From {1} WHERE tag = '{2}' and time='{3}'", fields, piTableType, tag, timeFilter);

            return selectCmd;
        }
        /// <summary>
        /// Get records from some table by tag in a time range
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="piTableType"></param>
        /// <param name="tag"></param>
        /// <param name="startDateTimeFilter"></param>
        /// <param name="endDateTimeFilter"></param>
        /// <returns></returns>
        protected string SelectCommand(string fields, string piTableType, string tag, string startDateTimeFilter, string endDateTimeFilter,string timeStep)
        {
            var selectCmd = String.Format("Select {0} From {1} WHERE tag = '{2}' and (time >='{3}' and time<='{4}') and TIMESTEP = RELDATE('{5}')", fields, piTableType, tag, startDateTimeFilter, endDateTimeFilter,timeStep);

            return selectCmd;
        }

        
        /// <summary>
        ///readings from Pi server can be either a float or scientific number
        ///ConvertReadingToDecimal checks for type of string is being passed in 
        ///and converts accordingly. Returning a float rounded to the 8th digit.
        /// </summary>
        /// <param name="reading"></param>
        /// <returns></returns>
        protected float ConvertReadingToDecimal(string reading)
        {
            float decReading;
            
            //if string is scientific number
            if (reading.Contains("E"))
            {
               
                decReading = (float)Math.Round(Double.Parse(reading, System.Globalization.NumberStyles.Float),4);
            }
            else
            {
                decReading = Convert.ToSingle(reading);
            }
            return decReading;
        }

    }
}
