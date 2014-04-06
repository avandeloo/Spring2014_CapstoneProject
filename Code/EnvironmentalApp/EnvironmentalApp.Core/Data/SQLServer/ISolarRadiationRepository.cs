using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.SQLServer
{
    public interface ISolarRadiationRepository
    {
        int Create(SolarRadiation entity);
        int Create(List<SolarRadiation> entityList);
        int Update(SolarRadiation entity);
        SolarRadiation Get(DateTime dateTime);
        List<SolarRadiation> Get(DateTime startTime, DateTime endTime);

    }
}
