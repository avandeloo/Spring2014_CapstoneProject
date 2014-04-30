using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Services.ETLServices;

namespace EnvironmentalApp.ConsoleApp.Contollers
{
    public class HourlyDataTransferController
    {
        //pbb transfer
        public int DataTransfer_AirTemp(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices airTempService = new ETL_AirTempService();
            return airTempService.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_ChilledWater(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices service = new ETL_ChilledWaterService();
            return service.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_Electric(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices service = new ETL_ElectricService();
            return service.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_Humidity(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices service = new ETL_HumidityService();
            return service.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_SolarRadiation(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices service = new ETL_SolarRadiationService();
            return service.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_SolarBusBarn(DateTime startTime, DateTime endTime)
        {
            var service = new ETL_SolarService();
            return service.SolarBusBarnTransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_SolarCarCharger(DateTime startTime, DateTime endTime)
        {
            var service = new ETL_SolarService();
            return service.SolarCarChargerTransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_Steam(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices service = new ETL_SteamService();
            return service.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_Wind(DateTime startTime, DateTime endTime)
        {
            Core.Services.IServices service = new ETL_WindService();
            return service.TransferPiHourlyToSqlHourly(startTime, endTime);
        }
        //campus data transfer
        public int DataTransfer_CampusChilledWater(DateTime startTime, DateTime endTime)
        {
            Core.Services.ICampusServices service = new ETL_ChilledWaterService();
            return service.CampusTransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_CampusSteam(DateTime startTime, DateTime endTime)
        {
            Core.Services.ICampusServices service = new ETL_SteamService();
            return service.CampusTransferPiHourlyToSqlHourly(startTime, endTime);
        }
        public int DataTransfer_CampusElectric(DateTime startTime, DateTime endTime)
        {
            Core.Services.ICampusServices service = new ETL_ElectricService();
            return service.CampusTransferPiHourlyToSqlHourly(startTime, endTime);
        }
    }
}
