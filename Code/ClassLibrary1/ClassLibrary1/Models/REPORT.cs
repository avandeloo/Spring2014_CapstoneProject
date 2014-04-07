using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class REPORT
    {
        public System.Guid ReportID { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string DataType { get; set; }
        public string GraphStyle { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string GeneratedBy { get; set; }
    }
}
