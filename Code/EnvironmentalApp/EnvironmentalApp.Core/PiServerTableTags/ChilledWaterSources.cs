using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnvironmentalApp.Core.PiServerTableTags
{
    public enum ChilledWaterSources
    {
        [Description("CWP_C35MMBTU/HR_PICalc")]
        PBB_ChilledWater,
        [Description("CWP_TOTAL_Chilled_Water_Production")]
        Campus_Total
    }
}
