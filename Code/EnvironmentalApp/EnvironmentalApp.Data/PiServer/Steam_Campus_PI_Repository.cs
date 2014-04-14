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
    public class Steam_Campus_PI_Repository : PiServerRepositoryBase, Core.Data.PiServer.ISteamRepository<Core.Models.Steam_Campus>
    {

        public Core.Models.Steam_Campus GetToday(SteamSources source)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source), "today");
            var steam = (Core.Models.Steam_Campus)ExecuteQuery(selectCmd)[0];
            return steam;
        }

        public Core.Models.Steam_Campus GetByTime(SteamSources source,string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source), time);
            var steam = (Core.Models.Steam_Campus)ExecuteQuery(selectCmd)[0];
            return steam;
        }

        public List<Core.Models.Steam_Campus> GetByTime(SteamSources source,string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source), "today");
            var steam = ExecuteQuery(selectCmd);
            return steam;
        }
        private List<Core.Models.Steam_Campus> ExecuteQuery(string selectCmd)
        {
            var steamList = new List<Core.Models.Steam_Campus>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Steam_Campus steam = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    steam = new Core.Models.Steam_Campus();
                    var currentRow = reader[rowIdx]; //tag
                    steam.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    steam.Reading = Convert.ToDecimal(reader[rowIdx + 2].ToString());
                    steam.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    steam.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    steam.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    steamList.Add(steam);
                }

            }
            return steamList;
        }
    }
}
