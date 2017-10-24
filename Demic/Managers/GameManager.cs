using Demic.Enums;
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
        private LocationManager _locationManager;
        private int _epidemicCards = 0;
        private BoardStateManager _boardState;

        public GameManager(IInteractionManager interactionManager)
        {
            _interactionManager = interactionManager;
            _locationManager = new LocationManager();
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
            //receive input from User
            _interactionManager.OutputContent(String.Format("Total Blue Cubes is currently {0}", _boardState.totalCubes(DiseaseColour.Blue)));
            var input = Int32.Parse(_interactionManager.ReadInput("Add a Number", new List<string>() { "1", "2", "3" }));
            _boardState.AddCubes(_locationManager.GetLocations().First(), input);
            TurnEnd();
        }

        private void TurnEnd()
        {
            //perform end of turn action, whilst checking for GameOver

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
            _boardState = new BoardStateManager(_locationManager);
            _epidemicCards = GetDifficulty();
            _interactionManager.OutputContent(String.Format("EpidemicCard Count is {0}", _epidemicCards));
        }

        private int GetDifficulty()
        {
            var difficulties = new List<string>();
            foreach (DifficultyLevel level in Enum.GetValues(typeof(DifficultyLevel)))
            {
                difficulties.Add(level.ToString());
            }

            var difficultyInput = _interactionManager.ReadInput("Please select a difficulty level for Epidemic", difficulties);
            DifficultyLevel difficultyLevel = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), difficultyInput);
            return (int)difficultyLevel;
        }
    }
}
