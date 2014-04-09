using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class Base_SQL_Repository
    {
        internal string ConnString = ""; 
        public Base_SQL_Repository()
        { 
            var config =new Configuration();
            ConnString = config.GetSqlServerConnectionString();
        }
    }
}
