using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Models
{
    public class BaseModelDailyTotals
    {
        public Guid Id { get; set; }
        public DateTime ReadingDateTime { get; set; }
        public float DailyAverage { get; set; }
        public float HighValue { get; set; }
        public float LowValue { get; set; }
        public float DailySum { get; set; }

    }
}
