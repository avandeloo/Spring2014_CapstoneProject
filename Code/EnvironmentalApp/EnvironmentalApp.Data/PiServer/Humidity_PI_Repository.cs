using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Data.PiServer
{
    public class Humidity_PI_Repository : PiServerRepositoryBase,  Core.Data.PiServer.IHumidityRepository
    {
        
   
        public Core.Models.Humidity GetToday(HumiditySources source)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source), "today");
            var humidity = (Core.Models.Humidity)ExecuteQuery(selectCmd)[0];
            return humidity;
        }

        public Core.Models.Humidity GetByTime(HumiditySources source,string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source), "today");
            var humidity = (Core.Models.Humidity)ExecuteQuery(selectCmd)[0];
            return humidity;
        }

        public List<Core.Models.Humidity> GetByTime(HumiditySources source,string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source), startDateTime, endDateTime);
            var humidity = (List<Core.Models.Humidity>)ExecuteQuery(selectCmd);
            return humidity;
        }

        private List<Core.Models.Humidity> ExecuteQuery(string selectCmd)
        {
            var humidityList = new List<Core.Models.Humidity>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Humidity humidity = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    humidity = new Core.Models.Humidity();
                    var currentRow = reader[rowIdx]; //tag
                    humidity.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    humidity.Reading = Convert.ToDecimal(reader[rowIdx + 2].ToString());
                    humidity.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    humidity.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    humidity.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    humidityList.Add(humidity);
                }

            }
            return humidityList;
        }
    }
}
