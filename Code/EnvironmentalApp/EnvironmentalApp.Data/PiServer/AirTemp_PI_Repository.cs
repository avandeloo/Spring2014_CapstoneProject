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
    public class AirTemp_PI_Repository : PiServerRepositoryBase, Core.Data.PiServer.IAirTempRepository
    {
       //string tableTag = EnumerationHelper.GetEnumDescription(Core.PiServerTableTags.AirTempSource.OutsideTemp);

        public Core.Models.AirTemp GetToday(AirTempSource airTempSource)
        {
           var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(airTempSource), "today");
           var airTemp = (Core.Models.AirTemp)ExecuteQuery(selectCmd)[0];
           return airTemp;
        }
            

        public Core.Models.AirTemp GetByTime(AirTempSource airTempSource,string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(airTempSource), time);
            var airTemp = (Core.Models.AirTemp)ExecuteQuery(selectCmd)[0];
            return airTemp;
        }

        public List<Core.Models.AirTemp> GetByTime(AirTempSource airTempSource,string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(airTempSource), startDateTime, endDateTime);
            var airTemp = ExecuteQuery(selectCmd);
            return airTemp;
        }
        private List<Core.Models.AirTemp> ExecuteQuery(string selectCmd)
        {
            var airTempList = new List<Core.Models.AirTemp>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.AirTemp airTemp = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    airTemp = new Core.Models.AirTemp();
                    var currentRow = reader[rowIdx]; //tag
                    airTemp.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    airTemp.Reading = reader[rowIdx + 2].ToString();
                    airTemp.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString()).Ticks;
                    airTemp.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    airTemp.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    airTempList.Add(airTemp);
                }

            }
            return airTempList;
        }
    }
}
