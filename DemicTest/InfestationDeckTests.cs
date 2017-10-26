using Demic.Managers;
using Demic.Classes;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemicTest
{
    [TestClass]
    public class InfestationDeckTests
    {
        [TestMethod]
        public void DrawSingleCardReturnsCorrectLocation()
        {
            var locationManager = new TestSingleLocationManager();
            var singleLocation = locationManager.GetLocations().First();
            var deck = new InfectionDeckManager(locationManager);
            var drawnLocation = deck.DrawCard();
            Assert.AreEqual<Location>(singleLocation, drawnLocation);
        }

        [TestMethod]
        public void DrawTwoCardCheckDifferent()
        {
            var locationManager = new TestLocationManager();
            var deck = new InfectionDeckManager(locationManager);
            var firstDrawnLocation = deck.DrawCard();
            var secondDrawnLocation = deck.DrawCard();
            Assert.AreNotEqual<Location>(firstDrawnLocation, secondDrawnLocation);
        }

        [TestMethod]
        public void CheckIntensifyPutsDiscardBackOnTop()
        {
            var locationManager = new TestLocationManager();
            var deck = new InfectionDeckManager(locationManager);
            var firstDrawnLocation = deck.DrawCard();
            deck.IntensifyShuffle();
            var secondDrawnLocation = deck.DrawCard();
            Assert.AreEqual<Location>(firstDrawnLocation, secondDrawnLocation);
        }

        [TestMethod]
        public void CheckCardsPostIntensifyArentSame()
        {
            var locationManager = new TestLocationManager();
            var deck = new InfectionDeckManager(locationManager);
            deck.DrawCard();
            deck.IntensifyShuffle();
            var firstDrawnLocation = deck.DrawCard();
            var secondDrawnLocation = deck.DrawCard();
            Assert.AreNotEqual<Location>(firstDrawnLocation, secondDrawnLocation);
        }
    }
}
