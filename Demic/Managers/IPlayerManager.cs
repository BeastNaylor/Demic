using Demic.Classes;
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
        void AddPlayer(Player player);

        void EndPlayerTurn();

        Player CurrentPlayerTurn();
    }
}
