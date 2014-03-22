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
        public ChilledWater GetToday()
        {
            var table = "CWP_C35MMBTU/HR_PICalc";
            return CurrentDayVaules(table);
        }

        public List<ChilledWater> GetByTime(string time)
        {

            var chillWaterList = new List<ChilledWater>();
            var table = "CWP_C35MMBTU/HR_PICalc";
            return GetValuesByTime(chillWaterList, table,time);


        }

        public List<ChilledWater> GetByTime(string startTime, string endTime)
        {

            var chillWaterList = new List<ChilledWater>();
            var table = "CWP_C35MMBTU/HR_PICalc";
            return GetValuesByTime(chillWaterList, table, startTime, endTime);

        }

        public ChilledWater CampusTotalToday()
        {
            var table = "CWP_TOTAL_Chilled_Water_Production";
            return CurrentDayVaules(table);
        }
        public List<ChilledWater> CapmusTotalByDate(string date)
        {
            var chillWaterList = new List<ChilledWater>();
            var table = "CWP_TOTAL_Chilled_Water_Production";
            return GetValuesByTime(chillWaterList, table, date);

        }
        public List<ChilledWater> CapmusTotalByDate(string startDate, string endDate)
        {
            var chillWaterList = new List<ChilledWater>();
            var table = "CWP_TOTAL_Chilled_Water_Production";
            return GetValuesByTime(chillWaterList, table, startDate, endDate);

        }

        private ChilledWater CurrentDayVaules(string table)
        {
            var selectCmd = SelectCommand("*", "piinterp", table, "today");
            var chilledWater = new ChilledWater();
            using (piServer)
            {
                piServer.Open();

                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    var currentRow = reader[rowIdx]; //tag
                    chilledWater.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    chilledWater.Reading = reader[rowIdx + 2].ToString();
                    chilledWater.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString()).Ticks;
                    chilledWater.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    chilledWater.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                }
            }
            return chilledWater;

        }
   
        private List<ChilledWater> GetValuesByTime( List<ChilledWater> chillWaterList, string table,string time, string endTime="")
        {
            var selectCmd = "";
            if (endTime.Equals(String.Empty))
            {
                selectCmd = SelectCommand("*", "piinterp", table, time);
            }
            else
            {
                selectCmd = SelectCommand("*", "piinterp", table, time,endTime);
            
            }
            using (piServer)
            {
                piServer.Open();

                var command = new OdbcCommand(selectCmd, piServer);
                var reader = command.ExecuteReader();
                var rowIdx = 0;
                while (reader.Read())
                {
                    var currentRow = reader[rowIdx]; //tag
                    var chilledWater = new ChilledWater();
                    chilledWater.ReadingDateTime = Convert.ToDateTime(reader[rowIdx + 1].ToString());
                    chilledWater.Reading = reader[rowIdx + 2].ToString();
                    chilledWater.TimeStamp = Convert.ToDateTime(reader[rowIdx + 1].ToString()).Ticks;
                    chilledWater.Status = Convert.ToInt32(reader[rowIdx + 3].ToString());
                    chilledWater.TimeStep = Convert.ToInt32(reader[rowIdx + 4].ToString());

                    chillWaterList.Add(chilledWater);

                }
            }


            return chillWaterList;
        }
       
       
    }
}
