﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demic.Managers
{
    class GameManager
    {
        private IInteractionManager _interactionManager;
        private int _num = 0;

        public GameManager(IInteractionManager interactionManager)
        {
            _interactionManager = interactionManager;
        }

        //entry point for GameManager
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
            _interactionManager.OutputContent(String.Format("Number is currently {0}", _num));
            var input = _interactionManager.ReadInput("Add a Number", new List<string>() { "1", "2", "3" });
            _num += int.Parse(input);
            TurnEnd();
        }

        private void TurnEnd()
        {
            //perform end of turn action, whilst checking for GameOver
            _num -= 2;
            if (_num < 0 || _num > 9)
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
            _num = 5;
        }
    }
}