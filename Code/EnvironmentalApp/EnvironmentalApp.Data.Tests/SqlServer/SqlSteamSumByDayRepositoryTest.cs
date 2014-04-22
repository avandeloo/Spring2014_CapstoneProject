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
    public class SqlSteamSumByDayRepositoryTest
    {
        List<Steam> steamList = new List<Steam>();

        [TestInitialize]
        public void SetUp()
        {
           
            steamList = steamList = new List<Steam> 
                { 
                    new Steam { Id = Guid.NewGuid(), Reading = 20.2f, ReadingDateTime = DateTime.Now.AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = 32.2f, ReadingDateTime = DateTime.Now.AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600},
                    new Steam { Id = Guid.NewGuid(), Reading = -48.2f, ReadingDateTime = DateTime.Now.AddHours(-1), Status = 1, TimeStamp = DateTime.Now, TimeStep = 3600}

                };
        
        }

        [TestMethod]
        public void Can_Insert_Daily_Sum()
        {
            var steamSumRepo = new Steam_DailyTotals_SQL_Repository();
           var result= steamSumRepo.Create(steamList);

           Assert.AreEqual(1, result);
        
        }
    }
}
