﻿using Demic.Enums;
using Demic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demic.Managers
{
    class GameManager
    {
        private IInteractionManager _interactionManager;
        private ILocationManager _locationManager;
        private IPlayerManager _playerManager;
        private int _epidemicCards;
        private int _infectionDrawCount;
        private BoardStateManager _boardState;
        private IInfectionDeckManager _infectionDeckManager;
        private ICureDeckManager _cureDeckManager;

        public GameManager(IInteractionManager interactionManager, ILocationManager locationManager, IPlayerManager playerManager)
        {
            _interactionManager = interactionManager;
            _locationManager = locationManager;
            _playerManager = playerManager;
        }

        public void Start()
        {
            //setup the initial state of the game
            SetupGame();
            //request action from the player
            RequestAction();
        }

        private void RequestAction()
        {
            OutputBoardState();
            //receive actions from the User
            var input = Int32.Parse(_interactionManager.ReadInput("Add a Number", new List<string>() { "1", "2", "3" }));
            TurnEnd();
        }

        private void OutputBoardState()
        {
            //this will output the state of the game currently, allowing the player to know what state the game is in
            //different levels of info, with drill down specifics
            //e.g.
            var player = _playerManager.CurrentPlayerTurn();
            _interactionManager.OutputContent(String.Format("Current Player is currently {0} at {1} with {2} actions", player.ToString(), player.CurrentLocation.Name, player.GetNumberOfActions()));
            foreach (string locationWithCubes in _boardState.OutputLocationsAndDiseaseCounts())
            {
                _interactionManager.OutputContent(locationWithCubes);
            }
        }

        private void TurnEnd()
        {
            //perform end of turn action, whilst checking for GameOver
            var cureCard = _cureDeckManager.DrawCard();
            //if you can't draw a cure card, it is gameover
            if (cureCard == null) { GameOver(); }
            _interactionManager.OutputContent(String.Format("Cure Card Drawn: {0}", cureCard.ToString()));
            _playerManager.EndPlayerTurn();
            DrawInfectionCards();
            if (_boardState.totalCubes(DiseaseColour.Blue) > 10)
            {
                GameOver();
            }
            else
            {
                //game not over, ask for new action
                RequestAction();
            }
        }

        private void DrawInfectionCards()
        {
            //draw cards from the infection deck and add cubes
            var drawnLocation = _infectionDeckManager.DrawCard();
            if (drawnLocation != null)
            {
                _boardState.AddCubes(drawnLocation, 1);
            }
        }

        private void DrawPlayerCards()
        {
            //draw cards from the player draw deck
        }

        private void GameOver()
        {
            //Game has ended, ask if want to play again
            _interactionManager.OutputContent("Game Over");
            var newGame = _interactionManager.ReadInput("Play Again", new List<string>() { "Y", "N" });
            if (newGame == "Y")
            {
                Start();
            }
            else
            {
                ExitGame();
            }
        }

        private void ExitGame()
        {
            Environment.Exit(0);
        }

        private void SetupGame()
        {
            //on setup, reset all variables to their defaults
            _boardState = new BoardStateManager(_locationManager);
            _infectionDeckManager = new InfectionDeckManager(_locationManager);
            _cureDeckManager = new CureDeckManager(_locationManager);
            _infectionDrawCount = Properties.Settings.Default.DEFAULT_INFECTION_DRAW;

            DifficultyLevel diffLevel = GetDifficulty();
            _epidemicCards = (int)diffLevel;

            int playerCount = GetPlayerCount();
            for (int index = 1; index <= playerCount; index++)
            {
                _interactionManager.OutputContent(String.Format("CHARACTER CREATION FOR PLAYER {0}", index));
                _playerManager.AddPlayer(GetPlayerRole());
            }

            _interactionManager.OutputContent(String.Format("Epidemic Card Count for {0} is {1}", diffLevel.ToString(), _epidemicCards));
            _interactionManager.OutputContent(String.Format("Press any key to start game..."));
            _interactionManager.Pause();
            _interactionManager.ClearOutput();
        }

        private DifficultyLevel GetDifficulty()
        {
            var difficulties = new List<string>();
            foreach (DifficultyLevel level in Enum.GetValues(typeof(DifficultyLevel)))
            {
                difficulties.Add(level.ToString());
            }

            var difficultyInput = _interactionManager.ReadInput("Please select a difficulty level for Epidemic", difficulties);
            DifficultyLevel difficultyLevel = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), difficultyInput);
            return difficultyLevel;
        }

        private int GetPlayerCount()
        {
            var playerCountInput = _interactionManager.ReadInput("Please select a number of players for Epidemic", new List<string>() { "2", "3", "4" });
            int playerCount = Int32.Parse(playerCountInput);
            return playerCount;
        }

        private PlayerRole GetPlayerRole()
        {
            var roles = new List<string>();
            foreach (PlayerRole role in Enum.GetValues(typeof(PlayerRole)))
            {
                if (!_playerManager.RoleInUse(role))
                roles.Add(role.ToString());
            }

            var playerRoleInput = _interactionManager.ReadInput("Please select a Player Role", roles);
            PlayerRole playerRole = (PlayerRole)Enum.Parse(typeof(PlayerRole), playerRoleInput);
            return playerRole;
        }
    }
}
