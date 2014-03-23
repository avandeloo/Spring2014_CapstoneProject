using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnvironmentalApp.Core.PiServerTableTags
{
    public enum ElectricSources
    {
        [Description("EL_PBB_TOTAL-KW")]
        PBB_Electric,
        [Description("PP_Electric_TCL")]
        Campus_Total
    }
}
