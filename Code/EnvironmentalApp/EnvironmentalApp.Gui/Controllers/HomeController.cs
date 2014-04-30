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
            if (id == null) { id = "AirTemp"; }
            if (sdate == null && edate == null) { sdate = DateTime.Now.AddDays(-4).ToString("MM/dd/yyyy"); edate = DateTime.Now.ToString("MM/dd/yyyy"); }
            switch (id.ToLower()) {
                case "airtemp":
                    getData_AirTemp(dataList, dataModel,sdate,edate);
                    break;
                case "pbbchilledwater":
                    getData_ChilledWater(dataList, dataModel, sdate, edate);
                    break;
                case "campuschilledwater":
                    getData_Camp_ChilledWater(dataList, dataModel, sdate, edate);
                    break;
                case "pbbelectric":
                    getData_PBB_Electric(dataList, dataModel, sdate, edate);
                    break;
                case "campuselectric":
                    getData_Camp_Electric(dataList, dataModel, sdate, edate);
                    break;
                case "humidity":
                    getData_Humidity(dataList, dataModel, sdate, edate);
                    break;
                case "solarradiation":
                    getData_SolarRadiation(dataList, dataModel, sdate, edate);
                    break;

                case "solarbusbarn":
                    getData_SolarServiceBusBarn(dataList, dataModel, sdate, edate);
                    break;

                case "solarcarport":
                    getData_SolarServiceCarPort(dataList, dataModel, sdate, edate);
                    break;

                case "steampbb":
                    getData_SteamPBB(dataList, dataModel, sdate, edate);
                    break;

                case "steamcampus":
                    getData_SteamCampus(dataList, dataModel, sdate, edate);
                    break;
                case "wind":
                    getData_Wind(dataList, dataModel, sdate, edate);
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

            var airTemp = artmp.Get_AirTemp_ByTime(AirTempSource.OutsideTemp, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Air Temperature";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "Fahrenheit";
            dataModel.Id = "airtemp";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < airTemp.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = airTemp[i].ReadingDateTime, Value = airTemp[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_ChilledWater(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_ChilledWaterService cws = new Pi_ChilledWaterService();

            var chilledWater = cws.Get_ChilledWater_ByTime(ChilledWaterSources.PBB_ChilledWater, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "PBB Chilled Water";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "MM BTU/HR";
            dataModel.Id = "pbbchilledwater";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < chilledWater.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = chilledWater[i].ReadingDateTime, Value = chilledWater[i].Reading });
            dataList.Add(dataModel);
        }
        private void getData_Camp_ChilledWater(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_ChilledWaterService cws = new Pi_ChilledWaterService();

            var chilledWater = cws.Get_ChilledWater_ByTime(ChilledWaterSources.Campus_Total, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Campus Chilled Water";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "MM BTU/HR";
            dataModel.Id = "chilledwater";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < chilledWater.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = chilledWater[i].ReadingDateTime, Value = chilledWater[i].Reading });
            dataList.Add(dataModel);
        }
        private static void getData_PBB_Electric(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_ElectricService elec = new Pi_ElectricService();

            var electric = elec.Get_Electric_ByTime(ElectricSources.PBB_Electric, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "PBB Electric";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "Total KW";
            dataModel.Id = "pbbelectric";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < electric.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = electric[i].ReadingDateTime, Value = electric[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_Camp_Electric(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_ElectricService elec = new Pi_ElectricService();

            var electric = elec.Get_Electric_ByTime(ElectricSources.Campus_Total, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Campus Electric";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "Total KW";
            dataModel.Id = "campuselectric";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < electric.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = electric[i].ReadingDateTime, Value = electric[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_Humidity(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_HumidityService hum = new Pi_HumidityService();

            var humidity = hum.Get_Humidity_ByTime(HumiditySources.Campus_Total, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Humidity";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "Percentage";
            dataModel.Id = "humidity";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < humidity.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = humidity[i].ReadingDateTime, Value = humidity[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SolarRadiation(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_SolarRadiationService solarr = new Pi_SolarRadiationService();

            var solarrad = solarr.Get_SolarRadiation_ByTime(SolarRadiationSources.Campus_Total, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Solar Radiation";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.Id = "solarradiation";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < solarrad.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = solarrad[i].ReadingDateTime, Value = solarrad[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SolarServiceBusBarn(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_SolarService sol = new Pi_SolarService();

            var solar = sol.Get_SolarBusBarn_ByTime(SolarSources.BusBarn, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Solar Bus Barn";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "KW";
            dataModel.Id = "solarbusbarn";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < solar.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = solar[i].ReadingDateTime, Value = solar[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SolarServiceCarPort(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_SolarService sol = new Pi_SolarService();

            var solar = sol.Get_SolarCarCharger_ByTime(SolarSources.CarPort, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Solar Car Port";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "KW";
            dataModel.Id = "solarcarport";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < solar.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = solar[i].ReadingDateTime, Value = solar[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SteamPBB(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_SteamService stPBB = new Pi_SteamService();

            var steamPBB = stPBB.Get_Steam_ByTime(SteamSources.PBB_Steam, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "PBB Steam";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "MM BTU/HR";
            dataModel.Id = "steampbb";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < steamPBB.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = steamPBB[i].ReadingDateTime, Value = steamPBB[i].Reading });
            dataList.Add(dataModel);
        }

        private static void getData_SteamCampus(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_SteamService stCampus = new Pi_SteamService();

            var steamCampus = stCampus.Get_SteamCampus_ByTime(SteamSources.Campus_Total, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Campus Steam";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "MM BTU/HR";
            dataModel.Id = "steamcampus";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < steamCampus.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = steamCampus[i].ReadingDateTime, Value = steamCampus[i].Reading });
            dataList.Add(dataModel);
        }
        private static void getData_Wind(List<Models.DataList> dataList, Models.DataList dataModel, string sdate, string edate)
        {
            Pi_WindService windService = new Pi_WindService();

            var steamCampus = windService.Get_Wind_ByTime(WindSources.WindTurbine, convertDate(sdate), convertDate(edate));
            dataModel.LineName = "Wind Turbine";
            dataModel.StartDate = sdate;
            dataModel.EndDate = edate;
            dataModel.DataUnit = "KW";
            dataModel.Id = "wind";
            dataModel.dataListData = new List<Models.DataModel>();
            for (int i = 0; i < steamCampus.Count; i++)
                dataModel.dataListData.Add(new Models.DataModel() { Date = steamCampus[i].ReadingDateTime, Value = steamCampus[i].Reading });
            dataList.Add(dataModel);
        }

       

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
