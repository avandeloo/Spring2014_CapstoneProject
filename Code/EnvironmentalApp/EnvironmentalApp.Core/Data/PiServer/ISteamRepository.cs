using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface ISteamRepository<T>
    {
        T GetToday(PiServerTableTags.SteamSources value);
        T GetByTime(PiServerTableTags.SteamSources value, string time);
        List<T> GetByTime(PiServerTableTags.SteamSources value, string startDateTime, string endDateTime);
    }
}
