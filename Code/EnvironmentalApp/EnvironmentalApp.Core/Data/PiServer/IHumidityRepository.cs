using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IHumidityRepository
    {
        Core.Models.Humidity GetToday(PiServerTableTags.HumiditySources value);
        Core.Models.Humidity GetByTime(PiServerTableTags.HumiditySources value, string time);
        List<Core.Models.Humidity> GetByTime(PiServerTableTags.HumiditySources value, string startDateTime, string endDateTime);
   
    }
}
