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
        public ActionResult Index2()
        {
            var dataList = new List<Models.DataList>();
            var dataModel = new Models.DataList();
             Pi_ChilledWaterService cws = new Pi_ChilledWaterService();

            var chilledWater = cws.Get_ChilledWater_ByTime(ChilledWaterSources.PBB_ChilledWater, "-2d", "today");
            dataModel.LineName = "ChilledWater";
            dataModel.Id = 1;
            dataModel.chilledWaterData = new List<Models.ChilledWaterModel>();
            for (int i = 0; i < chilledWater.Count; i++)
                dataModel.chilledWaterData.Add(new Models.ChilledWaterModel() { Date = chilledWater[i].ReadingDateTime, Value = Double.Parse(chilledWater[i].Reading) });
            dataList.Add(dataModel);

                return View(dataList);
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
