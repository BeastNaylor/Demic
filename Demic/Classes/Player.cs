using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Classes
{
    abstract class Player
    {
        abstract public PlayerRole Role { get; }
        public Location CurrentLocation;

        public Player()
        {
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
