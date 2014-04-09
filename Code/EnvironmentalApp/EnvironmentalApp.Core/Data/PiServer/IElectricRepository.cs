using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IElectricRepository<T>
    {
        T GetToday(PiServerTableTags.ElectricSources value);
        T GetByTime(PiServerTableTags.ElectricSources value, string time);
        List<T> GetByTime(PiServerTableTags.ElectricSources value, string startDateTime, string endDateTime);
    }
}
