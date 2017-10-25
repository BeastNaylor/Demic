using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Classes
{
    class Player
    {
        public readonly string Name;
        public readonly PlayerRole Role;

        public Player(string name, PlayerRole role)
        {
            this.Name = name;
            this.Role = role;
        }

        public override string ToString()
        {
            return String.Format("{0} the {1}", Name, Role.ToString());
        }

    }
}
