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
                    new Steam { Id = Guid.NewGuid(), Reading = "20.2", ReadingDateTime = DateTime.Now, Status = 1, TimeStamp = 12/28/2013, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = "32.2", ReadingDateTime = DateTime.Now, Status = 1, TimeStamp = 12/26/2013, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = "-48.2", ReadingDateTime = DateTime.Now, Status = 1, TimeStamp = 12/20/2013, TimeStep = 3600}

                };
            }

            [TestMethod]
            public void IndexGetsAllRecords()
            {
                var fakeSteamRepo = new PBBSteamRepository();
                Assert.AreEqual(3, steamList.Count);

                var result = fakeSteamRepo.Create(steamList);
                Assert.AreEqual(steamList.Count, result);
            }
        }
    }
