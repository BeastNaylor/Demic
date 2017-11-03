using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Classes
{
    class MedicPlayer : Player
    {
        public override PlayerRole Role
        {
            get { return PlayerRole.MEDIC; }
        }

        public MedicPlayer()
        {

        }
    }
}
