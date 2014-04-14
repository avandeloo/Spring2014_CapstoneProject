using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Data.PiServer
{
    public class Solar_BusBarn_PI_Repository:PiServerRepositoryBase, Core.Data.PiServer.ISolarRepository<Core.Models.Solar_BusBarn>
    {
        public Core.Models.Solar_BusBarn GetToday(Core.PiServerTableTags.SolarSources solarSource)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = (Core.Models.Solar_BusBarn)ExecuteQuery(selectCmd)[0];
            return solar;
        }


        public Core.Models.Solar_BusBarn GetByTime(Core.PiServerTableTags.SolarSources solarSource, string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = (Core.Models.Solar_BusBarn)ExecuteQuery(selectCmd)[0];
            return solar;
        }

        public List<Core.Models.Solar_BusBarn> GetByTime(Core.PiServerTableTags.SolarSources solarSource, string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = ExecuteQuery(selectCmd);
            return solar;
        }

        private string GetEnumDescription(Core.PiServerTableTags.SolarSources solarSource)
        {
            return Core.EnumerationHelper.GetEnumDescription((Core.PiServerTableTags.SolarSources)solarSource);
        }

        private List<Core.Models.Solar_BusBarn> ExecuteQuery(string selectCmd)
        {
            var solarList = new List<Core.Models.Solar_BusBarn>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Solar_BusBarn solar = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    solar = new Core.Models.Solar_BusBarn();
                    var currentRow = reader[rowIdx]; //tag
                    solar.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    solar.Reading = ConvertReadingToDecimal(reader[rowIdx + 2].ToString());//(decimal)Double.Parse(reader[rowIdx + 2].ToString(), System.Globalization.NumberStyles.Float);
                    solar.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    solar.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    solarList.Add(solar);
                }

            }
            return solarList;
        }

    }
}
