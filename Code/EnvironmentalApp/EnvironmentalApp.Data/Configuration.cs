using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.Entity;

namespace EnvironmentalApp.Data
{
    public class Configuration:Core.Configuration.IConfiguration
    {

        public string GetPiServerConnectionString()
        {

            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["piServer"].ConnectionString;
            return connString;


        }
        public static OdbcConnection GetPiServerConnection(string piServerConnectionString)
        {
            OdbcConnection piConnection = null;
            try
            {
                piConnection = new OdbcConnection(piServerConnectionString);
                return piConnection;
            }
            catch (OdbcException ex)
            {
                throw ex;
            }

           
        }
        public bool PiConnectionExists(string piServerConnectionString)
        {
            OdbcConnection piConnection = null;
          var result = false;
          try
          {
              piConnection = new OdbcConnection(piServerConnectionString);
              piConnection.Open();

              result = true;
          }
          catch (OdbcException ex)
          {
              result = false;
          }
          finally
          {
              if (piConnection.State == System.Data.ConnectionState.Open)
              {
                  piConnection.Close();
              }
              
          }
          return result;
        }

        public string GetSqlServerConnectionString()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["EnergyDataContext"].ConnectionString;
            return connString;
        }
        public string GetSqlServerConnectionStringName()
        {
            var connName = "";
            var connStringCollection =System.Configuration.ConfigurationManager.ConnectionStrings;
            for (int i = 0; i <connStringCollection.Count; i++)
            {
               var providerName= connStringCollection[i].ProviderName;
               var key = connStringCollection[i].Name;
               if (key == String.Empty || key == "LocalSqlServer")
               {
                   continue;
               }
               if (providerName == "System.Data.SqlClient")
               {
                   connName = connStringCollection[i].Name;
                   break;
               }
            
            }
            return connName;
        }
        public bool SqlDatabaseExists(string connString)
        {
            var result = false;
            try
            {
               result=  Database.Exists(connString);
            }catch(Exception ex){

                result = false;
            }
            return result;


        }
        public static SqlConnection GetSqlServerConnection(string sqlServerConnectionString)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(sqlServerConnectionString);
                return sqlConnection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }
    }
}
