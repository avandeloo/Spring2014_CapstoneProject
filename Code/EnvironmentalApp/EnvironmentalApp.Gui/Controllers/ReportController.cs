using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Services.SQLServerServices;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Gui.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult ReportDisplay(string id)
        {
            var dataList = new List<Models.ReportList>();
            dataList = ParseReport("Jon's Report");
            return View(dataList);
        }

        [HttpPost]
        public ActionResult Build(FormCollection collection)
        {
            generate_Report(collection);
            return View();
        }

        [HttpGet]
        public ActionResult Build()
        {
            return View();
        }

        public static List<Models.ReportList> ParseReport(string ReportName)
        {

            var reportList = new List<Models.ReportList>();
            //var reportModel = new Models.ReportList();
            var reportRepo = new Sql_ReportService();
            var dataRecord = new Report();
            dataRecord = reportRepo.Get_Report_ByName(ReportName);
            var dataTypeArray = dataRecord.DataType.Split(',');

            // take dates and times and combines them into DateTimes
            DateTime sDate = dataRecord.StartDate;
            TimeSpan sTime = dataRecord.StartTime;
            DateTime sDateTime = sDate + sTime;
            DateTime eDate = dataRecord.EndDate;
            TimeSpan eTime = dataRecord.EndTime;
            DateTime eDateTime = eDate + eTime;

            // determines which table to grab data from based on the current data type that is being parsed
            for (int i = 0; i < dataTypeArray.Length; i++)
            {
                var reportModel = new Models.ReportList();
                var tableName = dataTypeArray[i].Trim();
                switch (tableName)
                {
                    case "airtemp":
                        getSqlData_AirTemp(reportList, reportModel, sDateTime, eDateTime,dataRecord.GraphStyle);
                        break;
                    case "airtempdailytotals":
                        getSqlData_AirTempDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "pbbchilledwater":
                        getSqlData_PBB_ChilledWater(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "pbbchilledwaterdailytotals":
                        getSqlData_PBB_ChilledWaterDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "campuschilledwater":
                        getSqlData_Camp_ChilledWater(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "campuschilledwaterdailytotals":
                        getSqlData_Camp_ChilledWaterDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "pbbelectric":
                        getSqlData_PBB_Electric(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "pbbelectricdailytotals":
                        getSqlData_PBB_ElectricDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "campuselectric":
                        getSqlData_Camp_Electric(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "campuselectricdailytotals":
                        getSqlData_Camp_ElectricDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "humidity":
                        getSqlData_Humidity(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "humiditydailytotals":
                        getSqlData_HumidityDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "solarradiation":
                        getSqlData_SolarRadiation(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "solarradiationdailytotals":
                        getSqlData_SolarRadiationDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "solarbusbarn":
                        getSqlData_SolarServiceBusBarn(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "solarbusbarndailytotals":
                        getSqlData_SolarServiceBusBarnDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "solarcarcharger":
                        getSqlData_SolarServiceCarPort(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "solarcarchargerdailytotals":
                        getSqlData_SolarServiceCarPortDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "pbbsteam":
                        getSqlData_PBB_Steam(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "pbbsteamdailytotals":
                        getSqlData_PBB_SteamDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "steamcampus":
                        getSqlData_Camp_Steam(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "steamcampusdailytotals":
                        getSqlData_Camp_SteamDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "wind":
                        getSqlData_Wind(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                    case "winddailytotals":
                        getSqlData_WindDailyTotals(reportList, reportModel, sDateTime, eDateTime, dataRecord.GraphStyle);
                        break;
                }

            }

            return reportList;
        }

        private static void getSqlData_AirTemp(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate,string graphType)
        {
            Sql_AirTempService artmp = new Sql_AirTempService();

            var airTemp = artmp.Get_AirTemp_ByTime(sdate, edate);
            reportModel.LineName = "Air Temperature";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "Fahrenheit";
            reportModel.Id = "airtemp";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < airTemp.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = airTemp[i].ReadingDateTime, Value = airTemp[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_AirTempDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_AirTempService artmpdt = new Sql_AirTempService();

            var airTempDailyTotals = artmpdt.Get_AirTempDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Air Temperature";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "Fahrenheit";
            reportModel.Id = "airtemp";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < airTempDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = airTempDailyTotals[i].ReadingDateTime, Value = airTempDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_PBB_ChilledWater(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate,string graphType)
        {
            Sql_ChilledWaterService cw = new Sql_ChilledWaterService();

            var chilledWater = cw.Get_ChilledWater_ByTime(sdate, edate);
            reportModel.LineName = "PBB Chilled Water";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "pbbchilledwater";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < chilledWater.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = chilledWater[i].ReadingDateTime, Value = chilledWater[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_PBB_ChilledWaterDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate,string graphType)
        {
            Sql_ChilledWaterService cwdt = new Sql_ChilledWaterService();

            var chilledWaterDailyTotals = cwdt.Get_ChilledWaterDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "PBB Chilled Water Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "pbbchilledwaterdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < chilledWaterDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = chilledWaterDailyTotals[i].ReadingDateTime, Value = chilledWaterDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Camp_ChilledWater(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_ChilledWaterService cwc = new Sql_ChilledWaterService();

            var chilledWaterCampus = cwc.Get_ChilledWaterCampus_ByTime(sdate, edate);
            reportModel.LineName = "Campus Chilled Water";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "chilledwater";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < chilledWaterCampus.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = chilledWaterCampus[i].ReadingDateTime, Value = chilledWaterCampus[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Camp_ChilledWaterDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_ChilledWaterService cwcdt = new Sql_ChilledWaterService();

            var chilledWaterCampusDailyTotals = cwcdt.Get_ChilledWaterCampusDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Campus Chilled Water Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "chilledwaterdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < chilledWaterCampusDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = chilledWaterCampusDailyTotals[i].ReadingDateTime, Value = chilledWaterCampusDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_PBB_Electric(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_ElectricService elc = new Sql_ElectricService();

            var electric = elc.Get_Electric_ByTime(sdate, edate);
            reportModel.LineName = "PBB Electric";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "KW";
            reportModel.Id = "pbbelectric";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < electric.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = electric[i].ReadingDateTime, Value = electric[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_PBB_ElectricDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_ElectricService cwcdt = new Sql_ElectricService();

            var electricCampusDailyTotals = cwcdt.Get_ElectricCampusDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "PBB Electric Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "KW";
            reportModel.Id = "pbbelectricdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < electricCampusDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = electricCampusDailyTotals[i].ReadingDateTime, Value = electricCampusDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Camp_Electric(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_ElectricService elcc = new Sql_ElectricService();

            var electricCampus = elcc.Get_ElectricCampus_ByTime(sdate, edate);
            reportModel.LineName = "Campus Electric";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "KW";
            reportModel.Id = "electric";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < electricCampus.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = electricCampus[i].ReadingDateTime, Value = electricCampus[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Camp_ElectricDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_ElectricService elccdt = new Sql_ElectricService();

            var electricCampusDailyTotals = elccdt.Get_ElectricCampusDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Campus Electric Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "KW";
            reportModel.Id = "electricdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < electricCampusDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = electricCampusDailyTotals[i].ReadingDateTime, Value = electricCampusDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Humidity(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_HumidityService hmdty = new Sql_HumidityService();

            var humidity = hmdty.Get_Humidity_ByTime(sdate, edate);
            reportModel.LineName = "Humidity";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "Percentage";
            reportModel.Id = "humidity";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < humidity.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = humidity[i].ReadingDateTime, Value = humidity[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_HumidityDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_HumidityService hmdtydt = new Sql_HumidityService();

            var humidityDailyTotals = hmdtydt.Get_HumidityDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Humidity Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "Percentage";
            reportModel.Id = "humiditydailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < humidityDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = humidityDailyTotals[i].ReadingDateTime, Value = humidityDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_SolarRadiation(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SolarRadiationService slrrd = new Sql_SolarRadiationService();

            var solarRadiation = slrrd.Get_SolarRadiation_ByTime(sdate, edate);
            reportModel.LineName = "Solar Radiation";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "";
            reportModel.Id = "solarradiation";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < solarRadiation.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = solarRadiation[i].ReadingDateTime, Value = solarRadiation[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_SolarRadiationDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SolarRadiationService slrrddt = new Sql_SolarRadiationService();

            var solarRadiationDailyTotals = slrrddt.Get_SolarRadiationDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Solar Radiation Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "";
            reportModel.Id = "solarradiationdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < solarRadiationDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = solarRadiationDailyTotals[i].ReadingDateTime, Value = solarRadiationDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_SolarServiceBusBarn(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SolarService slrbb = new Sql_SolarService();

            var solarBusBarn = slrbb.Get_SolarBusBarn_ByTime(sdate, edate);
            reportModel.LineName = "Solar Bus Barn";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "";
            reportModel.Id = "solarbusbarn";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < solarBusBarn.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = solarBusBarn[i].ReadingDateTime, Value = solarBusBarn[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_SolarServiceBusBarnDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SolarService slrbbdt = new Sql_SolarService();

            var solarBusBarnDailyTotals = slrbbdt.Get_SolarBusBarnDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Solar Bus Barn Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "";
            reportModel.Id = "solarbusbarndailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < solarBusBarnDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = solarBusBarnDailyTotals[i].ReadingDateTime, Value = solarBusBarnDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_SolarServiceCarPort(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SolarService slrcp = new Sql_SolarService();

            var solarCarPort = slrcp.Get_SolarCarCharger_ByTime(sdate, edate);
            reportModel.LineName = "Solar Car Port";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "";
            reportModel.Id = "solarcarport";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < solarCarPort.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = solarCarPort[i].ReadingDateTime, Value = solarCarPort[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_SolarServiceCarPortDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SolarService slrcpdt = new Sql_SolarService();

            var solarCarPortDailyTotals = slrcpdt.Get_SolarCarChargerDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Solar Car Port Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "";
            reportModel.Id = "solarcarportdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < solarCarPortDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = solarCarPortDailyTotals[i].ReadingDateTime, Value = solarCarPortDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_PBB_Steam(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SteamService stm = new Sql_SteamService();

            var steam = stm.Get_Steam_ByTime(sdate, edate);
            reportModel.LineName = "PBB Steam";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "pbbsteam";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < steam.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = steam[i].ReadingDateTime, Value = steam[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_PBB_SteamDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SteamService stmdt = new Sql_SteamService();

            var steamDailyTotals = stmdt.Get_SteamDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "PBB Steam Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "pbbsteamdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < steamDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = steamDailyTotals[i].ReadingDateTime, Value = steamDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Camp_Steam(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SteamService stmc = new Sql_SteamService();

            var steamCampus = stmc.Get_SteamCampus_ByTime(sdate, edate);
            reportModel.LineName = "Campus Steam";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "steam";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < steamCampus.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = steamCampus[i].ReadingDateTime, Value = steamCampus[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Camp_SteamDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_SteamService stmdt = new Sql_SteamService();

            var steamCampusDailyTotals = stmdt.Get_SteamCampusDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Campus Steam Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "MM BTU/HR";
            reportModel.Id = "steamdailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < steamCampusDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = steamCampusDailyTotals[i].ReadingDateTime, Value = steamCampusDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        private static void getSqlData_Wind(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_WindService win = new Sql_WindService();

            var wind = win.Get_Wind_ByTime(sdate, edate);
            reportModel.LineName = "Wind Turbine";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "KW";
            reportModel.Id = "wind";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < wind.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = wind[i].ReadingDateTime, Value = wind[i].Reading });
            reportList.Add(reportModel);
        }

        private static void getSqlData_WindDailyTotals(List<Models.ReportList> reportList, Models.ReportList reportModel, DateTime sdate, DateTime edate, string graphType)
        {
            Sql_WindService windt = new Sql_WindService();

            var windDailyTotals = windt.Get_WindDailyTotals_ByTime(sdate, edate);
            reportModel.LineName = "Wind Daily Totals";
            reportModel.StartDate = sdate.ToString();
            reportModel.EndDate = edate.ToString();
            reportModel.DataUnit = "KW";
            reportModel.Id = "winddailytotals";
            reportModel.GraphType = graphType;
            reportModel.reportListData = new List<Models.ReportModel>();
            for (int i = 0; i < windDailyTotals.Count; i++)
                reportModel.reportListData.Add(new Models.ReportModel() { Date = windDailyTotals[i].ReadingDateTime, Value = windDailyTotals[i].DailyAverage });
            reportList.Add(reportModel);
        }

        // Generates report from user input
        public void generate_Report(FormCollection recordCollection)
        {
            var reportRepo = new Sql_ReportService();
            var report = new Report();
            report.ReportID = Guid.NewGuid();
            report.Name = recordCollection.Get("reportname");
            report.StartDate = Convert.ToDateTime(recordCollection.Get("sdate")).Date;
            report.EndDate = Convert.ToDateTime(recordCollection.Get("edate")).Date;
            report.StartTime = Convert.ToDateTime(recordCollection.Get("sdate")).TimeOfDay;
            report.EndTime = Convert.ToDateTime(recordCollection.Get("edate")).TimeOfDay;
            
            report.DataType= recordCollection["datatype"];

            if (report.DataType != null)
            {
                report.DataType = report.DataType.Remove(report.DataType.LastIndexOf(',')).Trim();
            }

            if (recordCollection.Get("graphtype") == "Line")
            {
                report.GraphStyle = "$.jqplot.TrendLine";
            }
            if (recordCollection.Get("graphtype") == "Bar")
            {
                report.GraphStyle = "$.jqplot.BarRenderer";
            }
            //if (recordCollection.Get("graphtype") == "Pie")
            //{
            //    report.GraphStyle = "jQuery.jqplot.PieRenderer";
            //}

            report.DateCreated = DateTime.Now;
            report.GeneratedBy = "John";
            report.Active = true;
            report.UpdatedBy = "Anthony";
            report.UpdateDate = DateTime.Now;
            if (report.Name != null)
            {
                reportRepo.Create_Report_Record(report);
            }

            
        }

       
    }
}
