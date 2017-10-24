using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demic.Managers;

namespace DemicTest
{
    [TestClass]
    public class LocationManagerTests
    {
        [TestMethod]
        public void NoDuplicateLocations()
        {
            var locationManager = new LocationManager();
            var locations = locationManager.GetLocations();
            var distinctLocations = locations.Select(loc => loc.Name).Distinct();
            Assert.AreEqual<int>(locations.Count(), distinctLocations.Count(), "There are Duplicate Locations");
        }
    }
}
