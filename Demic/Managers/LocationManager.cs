using Demic.Enums;
using Demic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    internal class LocationManager
    {
        private static IList<Location> _locations;

        public IEnumerable<Location> GetLocations()
        {
            if (_locations == null)
            {
                _locations = new List<Location>();
                _locations.Add(new Location() { Name = "Atlanta", Colour = DiseaseColour.Blue });
                _locations.Add(new Location() { Name = "Madrid", Colour = DiseaseColour.Blue });
                _locations.Add(new Location() { Name = "New York", Colour = DiseaseColour.Blue });
                _locations.Add(new Location() { Name = "Montreal", Colour = DiseaseColour.Blue });
                _locations.Add(new Location() { Name = "London", Colour = DiseaseColour.Blue });
                _locations.Add(new Location() { Name = "Miami", Colour = DiseaseColour.Yellow });

            }
            return _locations;
        }
    }
}
