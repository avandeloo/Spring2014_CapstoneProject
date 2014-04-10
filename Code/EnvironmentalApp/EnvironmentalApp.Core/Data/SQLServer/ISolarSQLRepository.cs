using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface ISolarSQLRepository<T>
    {
        int Create(T entity);
        int Create(List<T> entityList);
        int Update(T entity);
        T Get(DateTime dateTime);
        List<T> Get(DateTime startTime, DateTime endTime);

    }
}
