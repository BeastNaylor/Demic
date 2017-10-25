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
        public readonly string Name;
        public readonly PlayerRole Role; 
        public Location CurrentLocation;

        public Player(string name, PlayerRole role, Location startingLocation)
        {
            this.Name = name;
            this.Role = role;
            CurrentLocation = startingLocation;
        }

        public override string ToString()
        {
            return String.Format("{0} the {1}", Name, Role.ToString());
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            // object must be Test at this point
            Player otherPlayer = (Player)obj;
            return (this.Name == otherPlayer.Name && this.Role == otherPlayer.Role);
        }
    }
}
