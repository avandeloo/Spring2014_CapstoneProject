using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Data.PiServer
{
    public class Solar_CarCharger_PI_Repository:PiServerRepositoryBase,Core.Data.PiServer.ISolarRepository<Core.Models.Solar_CarCharger>
    {

        public Core.Models.Solar_CarCharger GetToday(Core.PiServerTableTags.SolarSources solarSource)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), "today");
            var solar = (Core.Models.Solar_CarCharger)ExecuteQuery(selectCmd)[0];
            return solar;
        }


        public Core.Models.Solar_CarCharger GetByTime(Core.PiServerTableTags.SolarSources solarSource, string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), time);
            var solar = (Core.Models.Solar_CarCharger)ExecuteQuery(selectCmd)[0];
            return solar;
        }

        public List<Core.Models.Solar_CarCharger> GetByTime(Core.PiServerTableTags.SolarSources solarSource, string startDateTime, string endDateTime, string timeStep = "1h")
        {
            var selectCmd = SelectCommand("*", "piinterp", GetEnumDescription(solarSource), startDateTime, endDateTime,timeStep);
            var solar = ExecuteQuery(selectCmd);
            return solar;
        }

        private string GetEnumDescription(Core.PiServerTableTags.SolarSources solarSource)
        {
            return Core.EnumerationHelper.GetEnumDescription((Core.PiServerTableTags.SolarSources)solarSource);
        }

        private List<Core.Models.Solar_CarCharger> ExecuteQuery(string selectCmd)
        {
            var solarList = new List<Core.Models.Solar_CarCharger>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Solar_CarCharger solar = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    solar = new Core.Models.Solar_CarCharger();
                    var currentRow = reader[rowIdx]; //tag
                    solar.Id = Guid.NewGuid();
                    solar.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    solar.Reading = ConvertReadingToDecimal(reader[rowIdx + 2].ToString());//Convert.ToDecimal(reader[rowIdx + 2].ToString());
                    solar.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    solar.TimeStamp = DateTime.Now;
                    solar.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    solarList.Add(solar);
                }

            }
            return solarList;
        }

    
    }
}
