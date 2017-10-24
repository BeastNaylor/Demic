using Demic.Enums;
using Demic.Classes;
using Demic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemicTest
{
    class TestLocationManager :ILocationManager
    {
        public IEnumerable<Location> GetLocations()
        {
            var locations = new List<Location>();
            locations.Add(new Location() { Name = "Atlanta", Colour = DiseaseColour.Blue });
            return locations;
        }
    }
}
