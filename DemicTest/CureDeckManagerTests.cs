using Demic.Classes;
using Demic.Managers;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemicTest
{
    [TestClass]
    public class CureDeckManagerTests
    {
        ILocationManager locationManager;

        [TestInitialize]
        public void Setup()
        {
            locationManager = new TestSingleLocationManager();
        }

        [TestMethod]
        public void CheckDrawSingleCard()
        {
            var cureDeck = new CureDeckManager(locationManager);
            var location = locationManager.GetLocations().First();
            var drawnCard = cureDeck.DrawCard();
            Assert.AreEqual<Location>(location, drawnCard);
        }
        [TestMethod]
        public void CheckOverdrawDeck()
        {
            var cureDeck = new CureDeckManager(locationManager);
            cureDeck.DrawCard();
            var secondCard = cureDeck.DrawCard();
            Assert.AreEqual<Location>(null, secondCard);
        }
    }
}
