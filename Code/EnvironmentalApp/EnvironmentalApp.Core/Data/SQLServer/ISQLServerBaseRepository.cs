using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface ISQLServerBaseRepository<T>
    {
        int Create(T entity);
        int Create(List<T> entityList);
        int Update(T entity);
        T Get(DateTime dateTime);
        List<T> Get(DateTime startTime, DateTime endTime);
    }
}
