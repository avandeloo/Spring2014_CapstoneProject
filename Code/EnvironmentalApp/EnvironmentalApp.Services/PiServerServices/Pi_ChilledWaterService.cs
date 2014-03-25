using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Data.PiServer;
using EnvironmentalApp.Data.PiServer;
using EnvironmentalApp.Core.PiServerTableTags;
namespace EnvironmentalApp.Services.PiServerServices
{
    public class Pi_ChilledWaterService
    {
        IPiServerRepository<Core.Models.ChilledWater,ChilledWaterSources> chilledWaterRepo = null;
        public Pi_ChilledWaterService()
        {
            chilledWaterRepo = new ChilledWaterRepository();
        }
        public Core.Models.ChilledWater Get_ChilledWater_ByTime(ChilledWaterSources source, string dateTime = "today")
        {
            var cWater = new Core.Models.ChilledWater();
            if (dateTime == "today")
            {
                cWater = chilledWaterRepo.GetToday(source);
            }
            else
            {
                cWater = chilledWaterRepo.GetByTime(source,dateTime);
            }

            return cWater;
        }
        public List<Core.Models.ChilledWater> Get_ChilledWater_ByTime(ChilledWaterSources source, string startDateTime, string endDateTime)
        {

            return chilledWaterRepo.GetByTime(source, startDateTime, endDateTime);
        }
    }
}
