using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IChilledWaterRespository: IPiServerRepository<ChilledWater>
    {
        ChilledWater CampusTotalToday();
        List<ChilledWater> CapmusTotalByDate(string date);
        List<ChilledWater> CapmusTotalByDate(string startDate,string endDate);
    }
}
