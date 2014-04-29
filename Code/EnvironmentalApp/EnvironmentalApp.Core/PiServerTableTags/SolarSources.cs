using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnvironmentalApp.Core.PiServerTableTags
{
    public enum SolarSources
    {
       [Description("EL_MSSB_S387_KV2.KW")]
        BusBarn,
        [Description("EL_MSSB_S388_KV2.KW")]
        CarPort

    }
}
