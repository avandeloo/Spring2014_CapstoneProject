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
        protected static string SelectCommand(string fields, string piTableType, string tag)
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
        protected static string SelectCommand(string fields, string piTableType, string tag, string timeFilter)
        {
            var selectCmd = String.Format("Select {0} From {1} WHERE tag = '{2}' and time='{3}'", fields, piTableType, tag,timeFilter);

            return selectCmd;
        }
        /// <summary>
        /// Get records from some table by tag in a time range
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="piTableType"></param>
        /// <param name="tag"></param>
        /// <param name="startTimeFilter"></param>
        /// <param name="endTimeFilter"></param>
        /// <returns></returns>
        protected static string SelectCommand(string fields, string piTableType, string tag, string startTimeFilter,string endTimeFilter)
        {
            var selectCmd = String.Format("Select {0} From {1} WHERE tag = '{2}' and (time >='{3}' and time<='{4}')", fields, piTableType, tag, startTimeFilter,endTimeFilter);

            return selectCmd;
        }

    }
}
