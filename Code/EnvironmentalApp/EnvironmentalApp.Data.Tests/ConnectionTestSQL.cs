using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace EnvironmentalApp.Data.Tests
{
    [TestClass]
    public class ConnectionTestSQL
    {
        [TestMethod]
        public void CanGetSQLConnectionStringDirectly()
        {
            var config = new Data.Configuration();
            Assert.IsNotNull(config, "Config was not intialized");

            var connString = config.GetSqlServerConnectionString();

            Assert.IsNotNull(connString, "config failed to intialize");
            Assert.IsTrue(connString.Length > 0, "connection string was empty");

        }
        [TestMethod]
        public void CanGetSQLConnectionStringInterface()
        {
            Core.Configuration.IConfiguration config = new Data.Configuration();
            Assert.IsNotNull(config, "Config was not intialized");

            var connString = config.GetSqlServerConnectionString();

            Assert.IsNotNull(connString, "config failed to intialize");
            Assert.IsTrue(connString.Length > 0, "connection string was empty");
        }
        [TestMethod]
        public void Can_Connect_To_SQL_Server()
        { 
            Core.Configuration.IConfiguration config = new Data.Configuration();
            SqlConnection SqlServer = Configuration.GetSqlServerConnection(config.GetSqlServerConnectionString());
            SqlServer.Open();
            
            Assert.IsTrue(SqlServer.State != System.Data.ConnectionState.Closed, "SQLServer connection failed");
            
        }
    }
}
