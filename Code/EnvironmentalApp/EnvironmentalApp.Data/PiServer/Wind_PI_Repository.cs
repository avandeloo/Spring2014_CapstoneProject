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
    public class Wind_PI_Repository : PiServerRepositoryBase, Core.Data.PiServer.IWindRepository
    {
       //string tableTag = EnumerationHelper.GetEnumDescription(Core.PiServerTableTags.wind.OutsideTemp);

        public Core.Models.Wind GetToday(WindSources windSource)
        {
           var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(windSource), "today");
           var wind = (Core.Models.Wind)ExecuteQuery(selectCmd)[0];
           return wind;
        }


        public Core.Models.Wind GetByTime(WindSources windSource, string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(windSource), time);
            var wind = (Core.Models.Wind)ExecuteQuery(selectCmd)[0];
            return wind;
        }

        public List<Core.Models.Wind> GetByTime(WindSources windSource, string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(windSource), startDateTime, endDateTime);
            var wind = ExecuteQuery(selectCmd);
            return wind;
        }
        private List<Core.Models.Wind> ExecuteQuery(string selectCmd)
        {
            var windList = new List<Core.Models.Wind>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Wind wind = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    wind = new Core.Models.Wind();
                    var currentRow = reader[rowIdx]; //tag
                    wind.Id = Guid.NewGuid();
                    wind.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    wind.Reading = ConvertReadingToDecimal(reader[rowIdx + 2].ToString());// Convert.ToDecimal(reader[rowIdx + 2].ToString());
                    wind.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    wind.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());
                    wind.TimeStamp = DateTime.Now;
                    windList.Add(wind);
                }

            }
            return windList;
        }
    }
}
