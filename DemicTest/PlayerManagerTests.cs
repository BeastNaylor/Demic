using Demic.Enums;
using Demic.Classes;
using Demic.Managers;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DemicTest
{
    [TestClass]
    public class PlayerManagerTests
    {
        ILocationManager locationManager;

        [TestInitialize]
        public void Setup()
        {
            locationManager = new TestLocationManager();
        }

        [TestMethod]
        public void AddPlayerAndCheckIsCurrent()
        {
            var playerManager = new PlayerManager(locationManager.StartingLocation);
            playerManager.AddPlayer(PlayerRole.MEDIC);
            Assert.AreEqual<int>(1, playerManager.NumberOfPlayers, "Player not successfully added");
        }

        [TestMethod]
        public void MultiplePlayerEndTurnChangesCurrentPlayer()
        {
            var playerManager = new PlayerManager(locationManager.StartingLocation);
            playerManager.AddPlayer(PlayerRole.MEDIC);
            playerManager.AddPlayer(PlayerRole.GENERALIST);
            var currentPlayer = playerManager.CurrentPlayerTurn();
            playerManager.EndPlayerTurn();
            var newCurrentPlayer = playerManager.CurrentPlayerTurn();
            Assert.AreEqual<bool>(false, currentPlayer.Equals(newCurrentPlayer), "Player Turn Ended, not changed Current Player");
        }

        [TestMethod]
        public void SingePlayerEndTurnSamePlayerNextTurn()
        {
            var playerManager = new PlayerManager(locationManager.StartingLocation);
            playerManager.AddPlayer(PlayerRole.MEDIC);
            var currentPlayer = playerManager.CurrentPlayerTurn();
            playerManager.EndPlayerTurn();
            var newCurrentPlayer = playerManager.CurrentPlayerTurn();
            Assert.AreEqual<bool>(true, currentPlayer.Equals(newCurrentPlayer));
        }

        [TestMethod]
        public void SameRoleAdded()
        {
            var playerManager = new PlayerManager(locationManager.StartingLocation);
            playerManager.AddPlayer(PlayerRole.MEDIC);
            Assert.AreEqual<bool>(true, playerManager.RoleInUse(PlayerRole.MEDIC));
        }

        [TestMethod]
        public void DifferentRoleAdded()
        {
            var playerManager = new PlayerManager(locationManager.StartingLocation);
            playerManager.AddPlayer(PlayerRole.MEDIC);
            Assert.AreEqual<bool>(false, playerManager.RoleInUse(PlayerRole.GENERALIST));
        }

        [TestMethod]
        public void CheckAllRolesGetPlayersCreated()
        {
            var roleCount = 0;
            var playerManager = new PlayerManager(locationManager.StartingLocation);
            var roles = new List<string>();
            foreach (PlayerRole role in Enum.GetValues(typeof(PlayerRole)))
            {
                roleCount++;
                playerManager.AddPlayer(role);
            }
            Assert.AreEqual<int>(roleCount, playerManager.NumberOfPlayers, "Not all roles have created players");

        }
    }
}