using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface ISolarRepository
    {
        int Create(Solar entity);
        int Create(List<Solar> entityList);
        int Update(Solar entity);
        Solar Get(DateTime dateTime);
        List<Solar> Get(DateTime startTime, DateTime endTime);

    }
}
