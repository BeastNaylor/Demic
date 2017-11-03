using Demic.Classes;
using Demic.Enums;
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
        private Location _startingLocation;

        public int NumberOfPlayers
        {
            get { return _playerList.Count; }
        }

        public bool RoleInUse(PlayerRole role)
        {
            return _playerList.Where(pl => pl.Role == role).Any();
        }

        public PlayerManager(Location startingLocation)
        {
            _startingLocation = startingLocation;
            _playerList = new List<Player>();
        }

        public void AddPlayer(PlayerRole role)
        {
            var player = GeneratePlayer(role);
            player.CurrentLocation =_startingLocation;
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

        private Player GeneratePlayer(PlayerRole role)
        {
            Player player = null;
            switch (role)
            {
                case PlayerRole.MEDIC:
                    player = new MedicPlayer();
                    break;
                case PlayerRole.GENERALIST:
                    player = new GeneralistPlayer();
                    break;
                case PlayerRole.RESEARCHER:
                    player = new ResearcherPlayer();
                    break;
                default:
                    break;
            }
            return player;
        }
    }
}
