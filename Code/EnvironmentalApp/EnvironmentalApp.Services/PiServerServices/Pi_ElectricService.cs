using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core.Data.PiServer;
using EnvironmentalApp.Data.PiServer;
namespace EnvironmentalApp.Services.PiServerServices
{
    public class Pi_ElectricService
    {
        IElectricRepository<Core.Models.Electric> electricRepo = null;
        IElectricRepository<Core.Models.Electric_Campus> electric_Campus_Repo = null;
        public Pi_ElectricService()
        {
            electricRepo = new Electric_PI_Repository();
            electric_Campus_Repo = new Electric_Campus_PI_Repository();
        }
        public Core.Models.Electric Get_Electric_ByTime(ElectricSources source, string dateTime = "today")
        {
            var electric = new Core.Models.Electric();
            if (dateTime.ToLower() == "today")
            { 
                electric = electricRepo.GetToday(source);
            }
            else
            {
                electric = electricRepo.GetByTime(source, dateTime);
            }

            return electric;
        }
        public List<Core.Models.Electric> Get_Electric_ByTime(ElectricSources source, string startDateTime, string endDateTime)
        {
            return electricRepo.GetByTime(source, startDateTime, endDateTime);
        }
    }
}
