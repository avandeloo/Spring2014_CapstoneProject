using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class OUTSIDE_AIR_TEMP
    {
        public System.Guid OutsideAirTempID { get; set; }
        public decimal Reading { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public System.DateTime ReadingDateTime { get; set; }
        public int TimeStep { get; set; }
        public int Status { get; set; }
    }
}
