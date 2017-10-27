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
            var loc = new Location("TESTLOC", DiseaseColour.Black);
            var playerOne = new Player(PlayerRole.MEDIC, loc);
            var playerTwo = new Player(PlayerRole.MEDIC, loc);
            Assert.AreEqual<bool>(true, playerOne.Equals(playerTwo));
        }

        [TestMethod]
        public void ComparePlayersWithdDifferentRole()
        {
            var loc = new Location("TESTLOC", DiseaseColour.Black);
            var playerOne = new Player(PlayerRole.MEDIC, loc);
            var playerTwo = new Player(PlayerRole.GENERALIST, loc);
            Assert.AreEqual<bool>(false, playerOne.Equals(playerTwo));
        }
    }
}
