using Demic.Enums;
using Demic.Classes;
using Demic.Managers;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemicTest
{
    [TestClass]
    public class PlayerManagerTests
    {
        [TestMethod]
        public void AddPlayerAndCheckIsCurrent()
        {
            var testPlayer = new Player("TEST", PlayerRole.MEDIC, new Location("TESTLOC", DiseaseColour.Black));
            var playerManager = new PlayerManager();
            playerManager.AddPlayer(testPlayer);
            Assert.AreEqual<int>(1, playerManager.NumberOfPlayers, "Player not successfully added");
        }

        [TestMethod]
        public void MultiplePlayerEndTurnChangesCurrentPlayer()
        {
            var testPlayerOne = new Player("TESTONE", PlayerRole.MEDIC, new Location("TESTLOC", DiseaseColour.Black));
            var testPlayerTwo = new Player("TESTTWO", PlayerRole.GENERALIST, new Location("TESTLOC", DiseaseColour.Black));
            var playerManager = new PlayerManager();
            playerManager.AddPlayer(testPlayerOne);
            playerManager.AddPlayer(testPlayerTwo);
            var currentPlayer = playerManager.CurrentPlayerTurn();
            playerManager.EndPlayerTurn();
            var newCurrentPlayer = playerManager.CurrentPlayerTurn();
            Assert.AreEqual<bool>(false, currentPlayer.Equals(newCurrentPlayer), "Player Turn Ended, not changed Current Player");
        }

        [TestMethod]
        public void SingePlayerEndTurnSamePlayerNextTurn()
        {
            var testPlayerOne = new Player("TESTONE", PlayerRole.MEDIC, new Location("TESTLOC", DiseaseColour.Black));
            var playerManager = new PlayerManager();
            playerManager.AddPlayer(testPlayerOne);
            var currentPlayer = playerManager.CurrentPlayerTurn();
            playerManager.EndPlayerTurn();
            var newCurrentPlayer = playerManager.CurrentPlayerTurn();
            Assert.AreEqual<bool>(true, currentPlayer.Equals(newCurrentPlayer));
        }

        [TestMethod]
        public void SameRoleAdded()
        {
            var testPlayerOne = new Player("TESTONE", PlayerRole.MEDIC, new Location("TESTLOC", DiseaseColour.Black));
            var playerManager = new PlayerManager();
            playerManager.AddPlayer(testPlayerOne);
            Assert.AreEqual<bool>(true, playerManager.RoleInUse(PlayerRole.MEDIC));
        }

        [TestMethod]
        public void DifferentRoleAdded()
        {
            var testPlayerOne = new Player("TESTONE", PlayerRole.MEDIC, new Location("TESTLOC", DiseaseColour.Black));
            var playerManager = new PlayerManager();
            playerManager.AddPlayer(testPlayerOne);
            Assert.AreEqual<bool>(false, playerManager.RoleInUse(PlayerRole.GENERALIST));
        }
    }
}