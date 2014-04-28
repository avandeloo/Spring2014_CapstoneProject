using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentalApp.Gui.Models
{
    public class DataModel
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
    }

    public class DataList
    {
        public int Id { get;set; }
        public string LineName { get; set; }
        public List<DataModel> dataListData { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DataUnit { get; set; }
    }
}