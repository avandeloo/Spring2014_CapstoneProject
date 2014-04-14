using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvironmentalApp.Services.PiServerServices;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Core.PiServerTableTags;

namespace EnvironmentalApp.Gui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult Index2(string id)
        {
            var dataList = new List<Models.DataList>();
            var dataModel = new Models.DataList();
            if (id == null) { id = "AirTemp"; }
            switch (id.ToLower()) {
                case "airtemp":
                    getData_AirTemp(dataList, dataModel);
                    break;
                case "chilledwater":
                    getData_ChilledWater(dataList, dataModel);
                    break;
            }
  
            return View(dataList);
        }

        private static void getData_AirTemp(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_AirTempService artmp = new Pi_AirTempService();

            var airTemp = artmp.Get_AirTemp_ByDateRange(AirTempSource.OutsideTemp, "-2d", "today");
            dataModel.LineName = "AirTemp";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < airTemp.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = airTemp[i].ReadingDateTime, Value = airTemp[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_ChilledWater(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_ChilledWaterService cws = new Pi_ChilledWaterService();

            var chilledWater = cws.Get_ChilledWater_ByTime(ChilledWaterSources.PBB_ChilledWater, "-2d", "today");
            dataModel.LineName = "ChilledWater";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < chilledWater.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = chilledWater[i].ReadingDateTime, Value = chilledWater[i].Reading });
            dataList.Add(dataModel);
        }

        //public ActionResult GetJsonResults()
        //{
        //    var modelList = new List<Models.ChilledWaterModel>();
           

        //    Pi_ChilledWaterService cws = new Pi_ChilledWaterService();

        //    List<ChilledWater> chilledWater = cws.Get_ChilledWater_ByTime(ChilledWaterSources.PBB_ChilledWater, "-2d", "today");
        //    foreach (var water in chilledWater)
        //    {
        //        var model = new Models.ChilledWaterModel();
        //        var dateAsInt = (int)(water.ReadingDateTime - new DateTime(1900, 1, 1)).TotalDays + 2;
        //        model.Label = "Chilled Water ";// water.ReadingDateTime.ToString();
        //        model.Series = new decimal[2] { dateAsInt, Decimal.Parse(water.Reading) };

        //        modelList.Add(model);
        //    }

        //    return Json(modelList);//, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
