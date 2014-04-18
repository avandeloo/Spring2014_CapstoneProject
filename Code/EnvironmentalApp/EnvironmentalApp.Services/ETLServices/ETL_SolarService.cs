﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Services;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core;


namespace EnvironmentalApp.Services.ETLServices
{
    public class ETL_SolarService : ETLBaseService
    {
        public int SolarCarCharger_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlSolarCarCharger = new SQLServerServices.Sql_SolarService();
            var PiSolarCarCharger = new PiServerServices.Pi_SolarService();
            var SolarCarChargerList = PiSolarCarCharger.Get_SolarCarCharger_ByDateRange(SolarSources.CarPort, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSolarCarCharger.Create_SolarCarCharger_List_Of_Records(SolarCarChargerList);
            return result;
        }

        public int SolarBusBarn_Fetch_And_Dump_Data_ByDateRange(DateTime startDate, DateTime endDate)
        {
            var SqlSolarBusBarn = new SQLServerServices.Sql_SolarService();
            var PiSolarBusBarn = new PiServerServices.Pi_SolarService();
            var SolarBusBarnList = PiSolarBusBarn.Get_SolarBusBarn_ByDateRange(SolarSources.BusBarn, DateTime_To_PiDateTime(startDate), DateTime_To_PiDateTime(endDate));
            var result = SqlSolarBusBarn.Create_SolarBusBarn_List_Of_Records(SolarBusBarnList);
            return result;
        }

    }
}
