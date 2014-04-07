﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Odbc;

namespace EnvironmentalApp.Data.Tests
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void CanGetPiConnectionStringDirectly()
        {
            var config = new Data.Configuration();
            Assert.IsNotNull(config, "Config was not intialized");

            var connString = config.GetPiServerConnectionString();

            Assert.IsNotNull(connString, "config failed to intialize");
            Assert.IsTrue(connString.Length > 0, "connection string was empty");

        }
        [TestMethod]
        public void CanGetPiConnectionStringInterface()
        {
            Core.Configuration.IConfiguration config = new Data.Configuration();
            Assert.IsNotNull(config, "Config was not intialized");

            var connString = config.GetPiServerConnectionString();

            Assert.IsNotNull(connString, "config failed to intialize");
            Assert.IsTrue(connString.Length > 0, "connection string was empty");
        }
        [TestMethod]
        public void Can_Connect_To_Pi_Server()
        { 
            Core.Configuration.IConfiguration config = new Configuration();
            OdbcConnection piServer = Configuration.GetPiServerConnection(config.GetPiServerConnectionString());

            Assert.IsTrue(piServer.State != System.Data.ConnectionState.Closed, "PiServer connection failed");
            
        }

        [TestMethod]
        public void CanGetSqlServerConnectionStringDirectly()
        {
            var config = new Data.Configuration();
            Assert.IsNotNull(config, "Config was not intialized");

            var connString = config. GetSqlServerConnectionString();

            Assert.IsNotNull(connString, "config failed to intialize");
            Assert.IsTrue(connString.Length > 0, "connection string was empty");

        }
        [TestMethod]
        public void Can_Connect_To_Sql_Server()
        {
            Core.Configuration.IConfiguration config = new Configuration();
            OdbcConnection piServer = Configuration.GetPiServerConnection(config.GetSqlServerConnectionString());

            Assert.IsTrue(piServer.State != System.Data.ConnectionState.Closed, "Sql Server connection failed");

        }
    }
}
