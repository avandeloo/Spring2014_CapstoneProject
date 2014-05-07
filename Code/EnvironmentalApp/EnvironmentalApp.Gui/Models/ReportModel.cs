using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalApp.Gui.Models
{
    public class ReportModel
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }

    }

    //public class DailyTotalsDataModel
    //{
    //    public DateTime ReadingDateTime { get; set; }
    //    public float DailyAverage { get; set; }
    //    public float HighValue { get; set; }
    //    public float LowValue { get; set; }
    //    public float DailySum { get; set; }
    //}

    public class ReportList
    {
        public string Id { get;set; }
        public string LineName { get; set; }
        public List<ReportModel> reportListData { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DataUnit { get; set; }
        public string GraphType { get; set; }

    }
    
    //public class DailyTotalsReportList
    //{
    //    public string Id { get; set; }
    //    public string LineName { get; set; }
    //    public List<DailyTotalsDataModel> reportListData { get; set; }
    //    public string StartDate { get; set; }
    //    public string EndDate { get; set; }
    //    public string DataUnit { get; set; }
    //}
}