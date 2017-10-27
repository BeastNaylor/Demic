using Demic.Classes;
using Demic.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    interface IPlayerManager
    {
        void AddPlayer(PlayerRole role);

        void EndPlayerTurn();

        Player CurrentPlayerTurn();

        bool RoleInUse(PlayerRole role);
    }
}
