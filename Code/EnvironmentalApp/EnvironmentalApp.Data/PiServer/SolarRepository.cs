using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Data.PiServer
{
    public class SolarRepository:PiServerRepositoryBase,Core.Data.PiServer.ISolarRepository
    {

        public Core.Models.Solar GetToday(Core.PiServerTableTags.SolarSource solarSource)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = (Core.Models.Solar)ExecuteQuery(selectCmd)[0];
            return solar;
        }


        public Core.Models.Solar GetByTime(Core.PiServerTableTags.SolarSource solarSource, string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = (Core.Models.Solar)ExecuteQuery(selectCmd)[0];
            return solar;
        }

        public List<Core.Models.Solar> GetByTime(Core.PiServerTableTags.SolarSource solarSource, string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = ExecuteQuery(selectCmd);
            return solar;
        }

        private string GetEnumDescription(Core.PiServerTableTags.SolarSource solarSource)
        {
            return Core.EnumerationHelper.GetEnumDescription((Core.PiServerTableTags.SolarSource)solarSource);
        }

        private List<Core.Models.Solar> ExecuteQuery(string selectCmd)
        {
            var solarList = new List<Core.Models.Solar>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Solar solar = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    solar = new Core.Models.Solar();
                    var currentRow = reader[rowIdx]; //tag
                    solar.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    solar.Reading = reader[rowIdx + 2].ToString();
                    solar.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString()).Ticks;
                    solar.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    solar.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    solarList.Add(solar);
                }

            }
            return solarList;
        }
    }
}
