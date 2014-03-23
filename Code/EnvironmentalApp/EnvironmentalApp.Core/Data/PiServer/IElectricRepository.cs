using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Core.Data.PiServer
{
    public interface IElectricRepository:IPiServerRepository<Core.Models.Electric,PiServerTableTags.ElectricSources>
    {
    }
}
