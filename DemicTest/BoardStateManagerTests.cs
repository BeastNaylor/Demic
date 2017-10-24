using Demic.Enums;
using Demic.Managers;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemicTest
{
    [TestClass]
    public class BoardStateManagerTests
    {
        [TestMethod]
        public void BlackCubesStartAtZero()
        {
            var testLocationManager = new TestLocationManager();
            var boardManager = new BoardStateManager(testLocationManager);
            Assert.AreEqual<int>(0, boardManager.totalCubes(DiseaseColour.Black), "Initial count for Black cubes is non-zero");
        }

        [TestMethod]
        public void AddCubeToAtlanta()
        {
            var testLocationManager = new TestLocationManager();
            var loc = testLocationManager.GetLocations().First();
            var boardManager = new BoardStateManager(testLocationManager);
            boardManager.AddCubes(loc, 2);
            Assert.AreEqual<int>(2, boardManager.totalCubes(loc.Colour), "Adding cubes doesn't increase total cubes");
        }
    }
}
