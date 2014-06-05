using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalApp.Services;
namespace EnvironmentalApp.ConsoleApp.Contollers
{
    public class ConfigurationController
    {
        ConfigurationServices configServices = new ConfigurationServices();

        public bool CanConnectToPi()
        {
            return configServices.CanConnectToPi();

        }
        public bool CanConnectToSql()
        {
            return configServices.CanConnectToSql();
        }
    }
}
