using Demic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    class PlayerManager : IPlayerManager
    {
        private List<Player> _playerList;

        public int NumberOfPlayers
        {
            get { return _playerList.Count; }
        }

        public PlayerManager()
        {
            _playerList = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _playerList.Add(player);
        }

        public void EndPlayerTurn()
        {
            var currentPlayer = _playerList[0];
            _playerList.RemoveAt(0);
            _playerList.Add(currentPlayer);
        }

        public Player CurrentPlayerTurn()
        {
            if (_playerList.Any())
            {
                return _playerList[0];
            }
            else
            {
                throw new IndexOutOfRangeException("No Players in Game");
            }
        }
    }
}
