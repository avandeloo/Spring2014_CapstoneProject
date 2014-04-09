using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface IWindSQLRepository
    {
        int Create(Wind entity);
        int Create(List<Wind> entityList);
        int Update(Wind entity);
        Wind Get(DateTime dateTime);
        List<Wind> Get(DateTime startTime, DateTime endTime);

    }
}
