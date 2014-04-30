using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using System.Data.Odbc;
using EnvironmentalApp.Core;
using EnvironmentalApp.Core.PiServerTableTags;
namespace EnvironmentalApp.Data.PiServer
{
    public class ChilledWater_PI_Repository : PiServerRepositoryBase, Core.Data.PiServer.IChilledWaterRespository<Core.Models.ChilledWater>
    {
        public ChilledWater GetToday(ChilledWaterSources chilledWaterSource)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(chilledWaterSource), "today");
            var chilledWater = (ChilledWater)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }

        public ChilledWater GetByTime(ChilledWaterSources chilledWaterSource,string time)
        {

            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(chilledWaterSource), time);
            var chilledWater = (ChilledWater)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }

        public List<ChilledWater> GetByTime(ChilledWaterSources chilledWaterSource,string startDateTime, string endDateTime,string timeStep="1h")
        {

            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(chilledWaterSource), startDateTime, endDateTime,timeStep);
            var chilledWater = (List<ChilledWater>)ExecuteQuery(selectCmd);
            return chilledWater;

        }

      

        private List<ChilledWater> ExecuteQuery(string selectCmd)
        {
            var chilledWaterList = new List<Core.Models.ChilledWater>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.ChilledWater chilledWater = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    chilledWater = new Core.Models.ChilledWater();
                    var currentRow = reader[rowIdx]; //tag
                    chilledWater.Id = Guid.NewGuid();
                    chilledWater.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    chilledWater.Reading = ConvertReadingToDecimal(reader[rowIdx + 2].ToString());//Convert.ToDecimal(reader[rowIdx + 2].ToString());
                    chilledWater.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    chilledWater.TimeStamp = DateTime.Now;
                    chilledWater.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    chilledWaterList.Add(chilledWater);
                }

            }
            return chilledWaterList;
        }

    }
}
