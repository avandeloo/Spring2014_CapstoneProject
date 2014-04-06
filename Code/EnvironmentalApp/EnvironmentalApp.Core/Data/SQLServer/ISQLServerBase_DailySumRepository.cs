using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface ISQLServerBase_DailySumRepository<T,E>
    {
        int Create(List<E> listOfDailyValues);
        T Get(DateTime dateTime);
        List<T> Get(DateTime startDate, DateTime endTime);

    }
}
