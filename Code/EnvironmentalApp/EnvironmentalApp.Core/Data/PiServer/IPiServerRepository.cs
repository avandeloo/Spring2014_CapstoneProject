using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IPiServerRepository<T,U> where U: struct, IComparable
    {
        T GetToday(U value) ;
        T GetByTime(U value,string time);
        List<T> GetByTime(U value,string startDateTime, string endDateTime);
    }
}
