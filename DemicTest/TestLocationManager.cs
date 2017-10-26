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
        public Location StartingLocation
        {
            get { return new Location("Atlanta", DiseaseColour.Blue); }
        }

        public IEnumerable<Location> GetLocations()
        {
            var locations = new List<Location>();
            locations.Add(new Location("Atlanta", DiseaseColour.Blue));
            locations.Add(new Location("Miami", DiseaseColour.Blue));
            locations.Add(new Location("New York", DiseaseColour.Blue));
            return locations;
        }
    }
}
