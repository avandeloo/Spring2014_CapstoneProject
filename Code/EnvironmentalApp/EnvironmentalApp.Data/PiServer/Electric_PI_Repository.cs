using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core;

namespace EnvironmentalApp.Data.PiServer
{
    public class Electric_PI_Repository : PiServerRepositoryBase, Core.Data.PiServer.IElectricRepository<Core.Models.Electric>
    {
        
        public Core.Models.Electric GetToday(ElectricSources source)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source));
            var electric = (Core.Models.Electric)ExecuteQuery(selectCmd)[0];
            return electric;
        }

        public Core.Models.Electric GetByTime(ElectricSources source,string time)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source));
            var electric = (Core.Models.Electric)ExecuteQuery(selectCmd)[0];
            return electric;
        }

        public List<Core.Models.Electric> GetByTime(ElectricSources source,string startDateTime, string endDateTime)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(source));
            var electric = ExecuteQuery(selectCmd);
            return electric;
        }
        private List<Core.Models.Electric> ExecuteQuery(string selectCmd)
        {
            var electricList = new List<Core.Models.Electric>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.Electric electric = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    electric = new Core.Models.Electric();
                    var currentRow = reader[rowIdx]; //tag
                    electric.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    electric.Reading = reader[rowIdx + 2].ToString();
                    electric.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString()).Ticks;
                    electric.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    electric.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    electricList.Add(electric);
                }

            }
            return electricList;
        }
    }
}
