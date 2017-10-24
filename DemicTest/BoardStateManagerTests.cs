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
        public void TotalCubesStartAtZero()
        {
            var testLocationManager = new TestLocationManager();
            var boardManager = new BoardStateManager(testLocationManager);
            var totalCubes = 0;
            foreach (DiseaseColour colour in Enum.GetValues(typeof(DiseaseColour)))
            {
                totalCubes += boardManager.totalCubes(colour);
            }
            Assert.AreEqual<int>(0, totalCubes, "Initial count for Cubes is non-zero");
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

        [TestMethod]
        public void SetCubesToThreeFromZeroAtAtlanta()
        {
            var testLocationManager = new TestLocationManager();
            var loc = testLocationManager.GetLocations().First();
            var boardManager = new BoardStateManager(testLocationManager);
            boardManager.SetCubes(loc, 3);
            Assert.AreEqual<int>(3, boardManager.totalCubes(loc.Colour), "Setting cubes to 3 doesn't result in correct number");
        }

        [TestMethod]
        public void SetCubesToThreeFromTwoAtAtlanta()
        {
            var testLocationManager = new TestLocationManager();
            var loc = testLocationManager.GetLocations().First();
            var boardManager = new BoardStateManager(testLocationManager);
            boardManager.AddCubes(loc, 2);
            boardManager.SetCubes(loc, 3);
            Assert.AreEqual<int>(3, boardManager.totalCubes(loc.Colour), "Increasing cubes to 3 from 2 doesn't result in correct number");
        }

        [TestMethod]
        public void OutbreakCountStartsAtZero()
        {
            var testLocationManager = new TestLocationManager();
            var boardManager = new BoardStateManager(testLocationManager);
            Assert.AreEqual<int>(0, boardManager.OutbreakCount);
        }
    }
}
