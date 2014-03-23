using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;
using System.Data.Odbc;

namespace EnvironmentalApp.Data.PiServer
{
    public class ChilledWaterRepository : PiServerRepositoryBase, Core.Data.PiServer.IChilledWaterRespository
    {
        string pbbTableTag = "CWP_C35MMBTU/HR_PICalc";
        string campusTableTag = "CWP_TOTAL_Chilled_Water_Production";
        public ChilledWater GetToday()
        {
            var selectCmd = SelectCommand("*", "piinterp", pbbTableTag, "today");
            var chilledWater = (ChilledWater)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }

        public ChilledWater GetByTime(string time)
        {

            var selectCmd = SelectCommand("*", "piinterp", pbbTableTag, time);
            var chilledWater = (ChilledWater)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }

        public List<ChilledWater> GetByTime(string startDateTime, string endDateTime)
        {

            var selectCmd = SelectCommand("*", "piinterp", pbbTableTag, startDateTime, endDateTime);
            var chilledWater = (List<ChilledWater>)ExecuteQuery(selectCmd);
            return chilledWater;

        }

        public ChilledWater CampusTotalToday()
        {

            var selectCmd = SelectCommand("*", "piinterp", campusTableTag, "today");
            var chilledWater = (ChilledWater)ExecuteQuery(selectCmd)[0];
            return chilledWater;
        }
        public ChilledWater CapmusTotalByDate(string date)
        {
            var selectCmd = SelectCommand("*", "piinterp", campusTableTag, date);
            var chilledWater = (ChilledWater)ExecuteQuery(selectCmd)[0];
            return chilledWater;

        }
        public List<ChilledWater> CapmusTotalByDate(string startDate, string endDate)
        {
            var selectCmd = SelectCommand("*", "piinterp", campusTableTag, startDate, endDate);
            var chilledWater = ExecuteQuery(selectCmd);
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
                    chilledWater.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    chilledWater.Reading = reader[rowIdx + 2].ToString();
                    chilledWater.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString()).Ticks;
                    chilledWater.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    chilledWater.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    chilledWaterList.Add(chilledWater);
                }

            }
            return chilledWaterList;
        }

    }
}
