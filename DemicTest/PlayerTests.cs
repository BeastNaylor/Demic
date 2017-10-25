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
        public void ComparePlayersWithSameNameAndRole()
        {
            var loc = new Location("TESTLOC", DiseaseColour.Black);
            var playerOne = new Player("ONE", PlayerRole.MEDIC, loc);
            var playerTwo = new Player("ONE", PlayerRole.MEDIC, loc);
            Assert.AreEqual<bool>(true, playerOne.Equals(playerTwo));
        }

        [TestMethod]
        public void ComparePlayersWithSameNameAndDifferentRole()
        {
            var loc = new Location("TESTLOC", DiseaseColour.Black);
            var playerOne = new Player("ONE", PlayerRole.MEDIC, loc);
            var playerTwo = new Player("ONE", PlayerRole.GENERALIST, loc);
            Assert.AreEqual<bool>(false, playerOne.Equals(playerTwo));
        }

        [TestMethod]
        public void ComparePlayersWithSameNameAndRoleDifferentLocation()
        {
            var locOne = new Location("TESTLOCONE", DiseaseColour.Black);
            var locTwo = new Location("TESTLOCTWO", DiseaseColour.Black);
            var playerOne = new Player("ONE", PlayerRole.MEDIC, locOne);
            var playerTwo = new Player("ONE", PlayerRole.MEDIC, locTwo);
            Assert.AreEqual<bool>(true, playerOne.Equals(playerTwo));
        }
    }
}
