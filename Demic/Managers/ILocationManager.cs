﻿using Demic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    interface ILocationManager
    {
        IEnumerable<Location> GetLocations();

        Location StartingLocation { get; }
    }
}
