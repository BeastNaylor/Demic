using Demic.Enums;
using Demic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    class LocationManager
    {
        public IEnumerable<Location> GetLocations()
        {
            IList<Location> locations = new List<Location>();
            locations.Add(new Location() { Name = "Atlanta", Colour = DiseaseColour.Blue });
            locations.Add(new Location() { Name = "Madrid", Colour = DiseaseColour.Blue });
            locations.Add(new Location() { Name = "New York", Colour = DiseaseColour.Blue });
            locations.Add(new Location() { Name = "Montreal", Colour = DiseaseColour.Blue });
            locations.Add(new Location() { Name = "London", Colour = DiseaseColour.Blue });
            locations.Add(new Location() { Name = "Miami", Colour = DiseaseColour.Yellow });
            return locations;
        }
    }
}
