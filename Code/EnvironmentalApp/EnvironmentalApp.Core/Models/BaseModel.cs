using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public long TimeStamp { get; set; }
        public DateTime ReadingDateTime { get; set; }
        public string Reading { get; set; }
        public int TimeStep { get; set; }
        public int Status { get; set; }

    }
}
