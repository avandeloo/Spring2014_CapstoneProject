using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class PBB_ELECTRIC
    {
        public System.Guid PBB_ElectricID { get; set; }
        public decimal Reading { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public System.DateTime ReadingDateTime { get; set; }
        public int TimeStep { get; set; }
        public int Status { get; set; }
    }
}
