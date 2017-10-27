using Demic.Classes;
using Demic.Enums;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemicTest
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void ComparePlayersWithSameRole()
        {
            var playerOne = new MedicPlayer();
            var playerTwo = new MedicPlayer();
            Assert.AreEqual<bool>(true, playerOne.Equals(playerTwo));
        }

        [TestMethod]
        public void ComparePlayersWithdDifferentRole()
        {
            var loc = new Location("TESTLOC", DiseaseColour.Black);
            var playerOne = new MedicPlayer();
            var playerTwo = new GeneralistPlayer();
            Assert.AreEqual<bool>(false, playerOne.Equals(playerTwo));
        }
    }
}
