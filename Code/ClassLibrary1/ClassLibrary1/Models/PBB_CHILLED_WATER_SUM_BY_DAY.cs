using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class PBB_CHILLED_WATER_SUM_BY_DAY
    {
        public System.Guid PBBChilledWaterSumByDayID { get; set; }
        public System.Guid TCSteamSumByDayID { get; set; }
        public System.DateTime ReadingDateTime { get; set; }
        public decimal DailySum { get; set; }
        public decimal DailyAverage { get; set; }
        public decimal HighValue { get; set; }
        public decimal LowValue { get; set; }
    }
}
