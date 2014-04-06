using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface IHumidityRepository
    {
        int Create(Humidity entity);
        int Update(Humidity entity);
        Humidity Get(DateTime dateTime);
        List<Humidity> Get(DateTime startTime, DateTime endTime);
    }
}
