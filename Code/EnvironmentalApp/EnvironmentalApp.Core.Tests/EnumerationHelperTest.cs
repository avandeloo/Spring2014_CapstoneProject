using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EnvironmentalApp.Core.Tests
{
    [TestClass]
    public class EnumerationHelperTest
    {
        [TestMethod]
        public void CanGetEnumDescription()
        {
            var result =EnumerationHelper.GetEnumDescription(PiServerTableTags.SolarSources.BusBarn);

            Assert.IsInstanceOfType(result, typeof(string),"Does not return correct type");
            Assert.AreEqual("El_Solar_Busbarn_Total_KW", result);
        }
    }
}
