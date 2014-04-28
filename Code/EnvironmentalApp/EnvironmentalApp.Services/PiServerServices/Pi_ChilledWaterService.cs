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
        IChilledWaterRespository<Core.Models.ChilledWater> chilledWaterRepo = null;
        IChilledWaterRespository<Core.Models.ChilledWater_Campus> chilledWater_Campus_Repo = null;
        public Pi_ChilledWaterService()
        {
            chilledWaterRepo = new ChilledWater_PI_Repository();
            chilledWater_Campus_Repo = new ChilledWater_Campus_PI_Repository();
        }
        
        // Chilled Water
        
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

        // Chilled Water Campus

        public Core.Models.ChilledWater_Campus Get_ChilledWaterCampus_ByTime(ChilledWaterSources source, string dateTime = "today")
        {
            var cWater = new Core.Models.ChilledWater_Campus();
            if (dateTime == "today")
            {
                cWater = chilledWater_Campus_Repo.GetToday(source);
            }
            else
            {
                cWater = chilledWater_Campus_Repo.GetByTime(source, dateTime);
            }

            return cWater;
        }
        public List<Core.Models.ChilledWater_Campus> Get_ChilledWaterCampus_ByTime(ChilledWaterSources source, string startDateTime, string endDateTime)
        {

            return chilledWater_Campus_Repo.GetByTime(source, startDateTime, endDateTime);
        }

    }
}
