using Demic.Classes;
using Demic.Enums;
using Demic.Properties;
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

        [TestMethod]
        public void CheckGeneralistHasAnExtraAction()
        {
            var generalist = new GeneralistPlayer();
            Assert.AreEqual(Settings.Default.DEFAULT_PLAYER_ACTIONS + 1, generalist.GetNumberOfActions());
        }

        [TestMethod]
        public void CheckMedicHasDefaultActions()
        {
            var generalist = new GeneralistPlayer();
            var medic = new MedicPlayer();
            Assert.AreEqual(Settings.Default.DEFAULT_PLAYER_ACTIONS, medic.GetNumberOfActions());
        }
    }
}
