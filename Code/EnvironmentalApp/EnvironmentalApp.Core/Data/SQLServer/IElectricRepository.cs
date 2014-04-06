using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface IElectricRepository
    {
        int Create(Electric entity);
        int Create(List<Electric> entityList);
        int Update(Electric entity);
        Electric Get(DateTime dateTime);
        List<Electric> Get(DateTime startTime, DateTime endTime);

    }
}
