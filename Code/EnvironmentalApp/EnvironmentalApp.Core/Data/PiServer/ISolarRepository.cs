using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface ISolarRepository
    {
        Core.Models.Solar GetToday(Core.PiServerTableTags.SolarSource solarSource);
        Core.Models.Solar GetByTime(Core.PiServerTableTags.SolarSource solarSource, string time);
        List<Core.Models.Solar> GetByTime(Core.PiServerTableTags.SolarSource solarSource, string startDateTime, string endDateTime);
    }
}
