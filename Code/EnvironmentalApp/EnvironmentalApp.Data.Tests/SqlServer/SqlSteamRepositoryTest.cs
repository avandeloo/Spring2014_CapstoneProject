using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.Core;
using EnvironmentalApp.Core.PiServerTableTags;
using EnvironmentalApp.Core.Models;
using EnvironmentalApp.Data.SQLServer.Repositories;
using System.Collections.Generic;


namespace EnvironmentalApp.Data.Tests.SqlServer
{
    [TestClass]
    public class SqlSteamRepositoryTest
    {
       
            private List<Steam> steamList = null;
            [TestInitialize]
            public void Setup()
            {
                steamList = new List<Steam> 
                { 
                    new Steam { Id = Guid.NewGuid(), Reading = 20.2m, ReadingDateTime = DateTime.Now.AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = 32.2m, ReadingDateTime = DateTime.Now.AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = -48.2m, ReadingDateTime = DateTime.Now.AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void IndexGetsAllRecords()
            {
                var fakeSteamRepo = new Steam_SQL_Repository();
                Assert.AreEqual(3, steamList.Count);

                var result = fakeSteamRepo.Create(steamList);
                Assert.AreEqual(steamList.Count, result);
            }
        }
    }
