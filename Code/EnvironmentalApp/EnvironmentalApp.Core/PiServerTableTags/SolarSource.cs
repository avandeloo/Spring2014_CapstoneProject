using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EnvironmentalApp.Core.PiServerTableTags
{
    public enum SolarSource
    {
       [Description("El_Solar_Busbarn_Total_KW")]
        BusBarn,
        [Description("EL_Solar_CarCharging_Total_KW")]
        CarPort
    }
}
