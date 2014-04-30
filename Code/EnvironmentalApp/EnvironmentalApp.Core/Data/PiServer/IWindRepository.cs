using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IWindRepository
    {
        Core.Models.Wind GetToday(PiServerTableTags.WindSources value);
        Core.Models.Wind GetByTime(PiServerTableTags.WindSources value, string time);
        List<Core.Models.Wind> GetByTime(PiServerTableTags.WindSources value, string startDateTime, string endDateTime, string timeStep = "1h");
   
    }
}
