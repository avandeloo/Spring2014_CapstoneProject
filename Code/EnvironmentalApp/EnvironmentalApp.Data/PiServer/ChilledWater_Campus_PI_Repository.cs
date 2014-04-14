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
    public class ChilledWater_Campus_PI_Repository : PiServerRepositoryBase, Core.Data.PiServer.IChilledWaterRespository<Core.Models.ChilledWater_Campus>
    {
        public ChilledWater_Campus GetToday(ChilledWaterSources chilledWaterSource)
        {
            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(chilledWaterSource), "today");
            var chilledWater = (ChilledWater_Campus)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }

        public ChilledWater_Campus GetByTime(ChilledWaterSources chilledWaterSource,string time)
        {

            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(chilledWaterSource), time);
            var chilledWater = (ChilledWater_Campus)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }

        public List<ChilledWater_Campus> GetByTime(ChilledWaterSources chilledWaterSource,string startDateTime, string endDateTime)
        {

            var selectCmd = SelectCommand("*", "piinterp", EnumerationHelper.GetEnumDescription(chilledWaterSource), startDateTime, endDateTime);
            var chilledWater = (List<ChilledWater_Campus>)ExecuteQuery(selectCmd);
            return chilledWater;

        }

      

        private List<ChilledWater_Campus> ExecuteQuery(string selectCmd)
        {
            var chilledWaterList = new List<Core.Models.ChilledWater_Campus>();
            using (piServer)
            {
                piServer.Open();
                Core.Models.ChilledWater_Campus chilledWater = null;
                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    chilledWater = new Core.Models.ChilledWater_Campus();
                    var currentRow = reader[rowIdx]; //tag
                    chilledWater.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    chilledWater.Reading = ConvertReadingToDecimal(reader[rowIdx + 2].ToString());//Convert.ToDecimal(reader[rowIdx + 2].ToString());
                    chilledWater.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    chilledWater.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    chilledWaterList.Add(chilledWater);
                }

            }
            return chilledWaterList;
        }

    }
}
