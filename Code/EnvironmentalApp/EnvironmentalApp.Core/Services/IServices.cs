using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Services
{
    public interface IServices
    {
         int TransferPiHourlyToSqlHourly(DateTime startTime, DateTime endtime);
         int CreateDailyTotalsValues();
    }
    public interface ICampusServices
    {
         int CampusTransferPiHourlyToSqlHourly(DateTime startTime, DateTime endtime);
         int CampusCreateDailyTotalsValues();
    
    }
}
