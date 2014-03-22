using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IPiServerRepository<T>
    {
        T GetToday();
        List<T> GetByTime(string time);
        List<T> GetByTime(string startDateTime, string endDateTime);
    }
}
