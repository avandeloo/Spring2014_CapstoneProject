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
        public decimal DailySum { get; set; }
        public decimal DailyAverage { get; set; }
        public decimal HighValue { get; set; }
        public decimal LowValue { get; set; }

    }
}
