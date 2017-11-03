using Demic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Classes
{
    class GeneralistPlayer : Player
    {
        public override PlayerRole Role
        {
            get { return PlayerRole.GENERALIST; }
        }

        public override int GetNumberOfActions()
        {
            return base.GetNumberOfActions() +1;
        }
    }
}
