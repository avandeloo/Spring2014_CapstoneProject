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

        public ActionResult Index2(string id,string sdate, string edate)
        {
            var dataList = new List<Models.DataList>();
            var dataModel = new Models.DataList();
            if (id == null) { id = "AirTemp"; sdate = DateTime.Now.AddDays(-4).ToString("MM/dd/yyyy"); edate = DateTime.Now.ToString("MM/dd/yyyy"); ; }
            switch (id.ToLower()) {
                case "airtemp":
                    getData_AirTemp(dataList, dataModel,sdate,edate);
                    break;
                case "chilledwater":
                    getData_ChilledWater(dataList, dataModel);
                    break;
                case "pbbelectric":
                    getData_PBB_Electric(dataList, dataModel);
                    break;
                case "campuselectric":
                    getData_Camp_Electric(dataList, dataModel);
                    break;
                case "humidity":
                    getData_Humidity(dataList, dataModel);
                    break;
                case "solarradiation":
                    getData_SolarRadiation(dataList, dataModel);
                    break;

                case "solarbusbarn":
                    getData_SolarServiceBusBarn(dataList, dataModel);
                    break;

                case "solarcarport":
                    getData_SolarServiceCarPort(dataList, dataModel);
                    break;

                case "steampbb":
                    getData_SteamPBB(dataList, dataModel);
                    break;

                case "steamcampus":
                    getData_SteamCampus(dataList, dataModel);
                    break;
            }
  
            return View(dataList);
        }

        private static string convertDate(string date)
        {
            var convDate = "";

            convDate = Convert.ToDateTime(date).ToString("dd-MMM-yy");

            return convDate;
        }

        private static void getData_AirTemp(List<Models.DataList> dataList, Models.DataList dataModel,string sdate, string edate)
        {
            Pi_AirTempService artmp = new Pi_AirTempService();

            var airTemp = artmp.Get_AirTemp_ByDateRange(AirTempSource.OutsideTemp, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Air Temperature";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
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
            dataModel.LineName = "Chilled Water";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < chilledWater.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = chilledWater[i].ReadingDateTime, Value = chilledWater[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_PBB_Electric(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_ElectricService elec = new Pi_ElectricService();

            var electric = elec.Get_Electric_ByTime(ElectricSources.PBB_Electric, "-2d", "today");
            dataModel.LineName = "Papa John Electric";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < electric.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = electric[i].ReadingDateTime, Value = electric[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_Camp_Electric(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_ElectricService elec = new Pi_ElectricService();

            var electric = elec.Get_Electric_ByTime(ElectricSources.Campus_Total, "-2d", "today");
            dataModel.LineName = "Campus Electric";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < electric.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = electric[i].ReadingDateTime, Value = electric[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_Humidity(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_HumidityService hum = new Pi_HumidityService();

            var humidity = hum.Get_Humidity_ByDateRange(HumiditySources.Campus_Total, "-2d", "today");
            dataModel.LineName = "Humidity";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < humidity.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = humidity[i].ReadingDateTime, Value = humidity[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SolarRadiation(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_SolarRadiationService solarr = new Pi_SolarRadiationService();

            var solarrad = solarr.Get_SolarRadiation_ByDateRange(SolarRadiationSources.Campus_Total, "-2d", "today");
            dataModel.LineName = "Solar Radiation";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < solarrad.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = solarrad[i].ReadingDateTime, Value = solarrad[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SolarServiceBusBarn(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_SolarService sol = new Pi_SolarService();

            var solar = sol.Get_Solar_ByDateRange(SolarSources.BusBarn, "-2d", "today");
            dataModel.LineName = "Solar Bus Barn";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < solar.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = solar[i].ReadingDateTime, Value = solar[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SolarServiceCarPort(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_SolarService sol = new Pi_SolarService();

            var solar = sol.Get_Solar_ByDateRange(SolarSources.CarPort, "-2d", "today");
            dataModel.LineName = "Solar Car Port";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < solar.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = solar[i].ReadingDateTime, Value = solar[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SteamPBB(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_SteamService stPBB = new Pi_SteamService();

            var steamPBB = stPBB.Get_Steam_ByDateRange(SteamSources.PBB_Steam, "-2d", "today");
            dataModel.LineName = "Steam PBB";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < steamPBB.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = steamPBB[i].ReadingDateTime, Value = steamPBB[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SteamCampus(List<Models.DataList> dataList, Models.DataList dataModel)
        {
            Pi_SteamService stCampus = new Pi_SteamService();

            var steamCampus = stCampus.Get_Steam_ByDateRange(SteamSources.Campus_Total, "-2d", "today");
            dataModel.LineName = "Steam Campus";
            dataModel.Id = 1;
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < steamCampus.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = steamCampus[i].ReadingDateTime, Value = steamCampus[i].Reading });
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
        //        model.Series = new decimal[2] { dateAsInt, Decimal.Parse(water.Reading };

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
