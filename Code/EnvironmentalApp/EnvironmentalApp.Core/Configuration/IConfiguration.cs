using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
namespace EnvironmentalApp.Core.Configuration
{
    public interface IConfiguration
    {
         string GetPiServerConnectionString();
         string GetSqlServerConnectionString();
    }
}
