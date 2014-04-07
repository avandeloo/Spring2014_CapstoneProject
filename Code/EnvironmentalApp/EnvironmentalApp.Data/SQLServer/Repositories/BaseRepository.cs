using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentalApp.Data.SQLServer.Repositories
{
    public class BaseRepository
    {
        internal string ConnString = ""; 
        public BaseRepository()
        { 
            var config =new Configuration();
            ConnString = config.GetSqlServerConnectionString();
        }
    }
}
