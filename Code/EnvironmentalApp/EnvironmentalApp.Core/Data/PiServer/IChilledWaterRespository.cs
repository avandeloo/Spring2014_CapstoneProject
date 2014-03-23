using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Core.Models;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IChilledWaterRespository : Data.PiServer.IPiServerRepository<ChilledWater,PiServerTableTags.ChilledWaterSources>
    {
      
    }
}
