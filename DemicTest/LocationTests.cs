using Demic.Classes;
using Demic.Enums;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemicTest
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void CompareSameLocationWithDifferentDisease()
        {
            var locOne = new Location("TESTLOCONE", DiseaseColour.Black);
            var locTwo = new Location("TESTLOCONE", DiseaseColour.Blue);
            Assert.AreEqual<bool>(true, locOne.Equals(locTwo));
        }
    }
}
