using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Classes
{
    internal class Player
    {
        public readonly PlayerRole Role; 
        public Location CurrentLocation;

        public Player(PlayerRole role, Location startingLocation)
        {
            this.Role = role;
            CurrentLocation = startingLocation;
        }

        public override string ToString()
        {
            return Role.ToString();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;

            Player otherPlayer = (Player)obj;
            return (this.Role == otherPlayer.Role);
        }

        public override int GetHashCode()
        {
            return this.Role.GetHashCode();
        }
    }
}
