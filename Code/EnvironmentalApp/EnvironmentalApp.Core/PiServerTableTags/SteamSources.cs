using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnvironmentalApp.Core.PiServerTableTags
{
    public enum SteamSources
    {
        [Description("MC_200_MMBTU/HR_Calc")]
        PBB_Steam,
        [Description("PP_TOTAL_Campus_Steam_Delivered_MMBTU/HR")]
        Campus_Total
    }
}
