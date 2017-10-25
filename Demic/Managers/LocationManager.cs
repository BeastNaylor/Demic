using Demic.Enums;
using Demic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    internal class LocationManager : ILocationManager
    {
        private static IList<Location> _locations;

        public IEnumerable<Location> GetLocations()
        {
            if (_locations == null)
            {
                _locations = new List<Location>();
                _locations.Add(new Location("Atlanta", DiseaseColour.Blue));
                _locations.Add(new Location("Madrid", DiseaseColour.Blue));
                _locations.Add(new Location("New York", DiseaseColour.Blue));
                _locations.Add(new Location("Montreal", DiseaseColour.Blue));
                _locations.Add(new Location("London", DiseaseColour.Blue));
                _locations.Add(new Location("Miami", DiseaseColour.Yellow));

            }
            return _locations;
        }
    }
}
