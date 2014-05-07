using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvironmentalApp.ConsoleApp.Contollers;

namespace EnvironmentalApp.Console.Tests
{
    [TestClass]
    public class DailyTotalsTest
    {
        DailyTotalsCalculationController dailyTotalsContrl = null;
        [TestInitialize]
        public void Setup()
        {
            dailyTotalsContrl = new DailyTotalsCalculationController();
        }
        [TestMethod]
        public void CanCalculateAirTotals()
        {
            dailyTotalsContrl.CalculateDailyTotals_AirTemp();

        }
    }
}
