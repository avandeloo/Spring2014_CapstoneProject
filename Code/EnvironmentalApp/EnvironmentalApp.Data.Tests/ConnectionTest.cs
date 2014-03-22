using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
