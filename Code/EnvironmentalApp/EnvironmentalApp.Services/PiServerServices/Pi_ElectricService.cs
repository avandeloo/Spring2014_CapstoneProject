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
        IPiServerRepository<Core.Models.Electric,ElectricSources> electricRepo = null;
        public Pi_ElectricService()
        {
            electricRepo = new ElectricRepository();
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
