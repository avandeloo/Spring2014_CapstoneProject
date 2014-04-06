using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface ISteamRepository
    {
        int Create(Steam entity);
        int Create(List<Steam> entityList);
        int Update(Steam entity);
        Steam Get(DateTime dateTime);
        List<Steam> Get(DateTime startTime, DateTime endTime);

    }
}
