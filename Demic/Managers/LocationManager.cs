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

        public LocationManager()
        {
            GetLocations();
        }

        public Location StartingLocation
        {
            get { return _locations.Where(loc => loc.Name == Properties.Settings.Default.DEFAULT_STARTING_LOCATION).Single(); }
        }

        public IEnumerable<Location> GetLocations()
        {
            if (_locations == null)
            {
                _locations = new List<Location>();
                _locations.Add(new Location("San Francisco", DiseaseColour.Blue));
                _locations.Add(new Location("Chicago", DiseaseColour.Blue));
                _locations.Add(new Location("Atlanta", DiseaseColour.Blue));
                _locations.Add(new Location("Toronto", DiseaseColour.Blue));
                _locations.Add(new Location("Washington DC", DiseaseColour.Blue));
                _locations.Add(new Location("New York", DiseaseColour.Blue));
                _locations.Add(new Location("London", DiseaseColour.Blue));
                _locations.Add(new Location("Madrid", DiseaseColour.Blue));
                _locations.Add(new Location("Paris", DiseaseColour.Blue));
                _locations.Add(new Location("Essen", DiseaseColour.Blue));
                _locations.Add(new Location("Milan", DiseaseColour.Blue));
                _locations.Add(new Location("St Petersburg", DiseaseColour.Blue));
                _locations.Add(new Location("Los Angeles", DiseaseColour.Yellow));
                _locations.Add(new Location("Mexico City", DiseaseColour.Yellow));
                _locations.Add(new Location("Miami", DiseaseColour.Yellow));
                _locations.Add(new Location("Bogota", DiseaseColour.Yellow));
                _locations.Add(new Location("Lima", DiseaseColour.Yellow));
                _locations.Add(new Location("Santiago", DiseaseColour.Yellow));
                _locations.Add(new Location("Buenos Aires", DiseaseColour.Yellow));
                _locations.Add(new Location("Sao Paulo", DiseaseColour.Yellow));
                _locations.Add(new Location("Lagos", DiseaseColour.Yellow));
                _locations.Add(new Location("Khartoum", DiseaseColour.Yellow));
                _locations.Add(new Location("Kinshasa", DiseaseColour.Yellow));
                _locations.Add(new Location("Johannesburg", DiseaseColour.Yellow));
                _locations.Add(new Location("Algiers", DiseaseColour.Black));
                _locations.Add(new Location("Cairo", DiseaseColour.Black));
                _locations.Add(new Location("Istanbul", DiseaseColour.Black));
                _locations.Add(new Location("Baghdad", DiseaseColour.Black));
                _locations.Add(new Location("Riyadh", DiseaseColour.Black));
                _locations.Add(new Location("Moscow", DiseaseColour.Black));
                _locations.Add(new Location("Tehran", DiseaseColour.Black));
                _locations.Add(new Location("Mumbai", DiseaseColour.Black));
                _locations.Add(new Location("Delhi", DiseaseColour.Black));
                _locations.Add(new Location("Karachi", DiseaseColour.Black));
                _locations.Add(new Location("Chennai", DiseaseColour.Black));
                _locations.Add(new Location("Kolkata", DiseaseColour.Black));
                _locations.Add(new Location("Bangkok", DiseaseColour.Red));
                _locations.Add(new Location("Jakarta", DiseaseColour.Red));
                _locations.Add(new Location("Ho Chi Minh City", DiseaseColour.Red));
                _locations.Add(new Location("Manilla", DiseaseColour.Red));
                _locations.Add(new Location("Hong Kong", DiseaseColour.Red));
                _locations.Add(new Location("Sydney", DiseaseColour.Red));
                _locations.Add(new Location("Taipei", DiseaseColour.Red));
                _locations.Add(new Location("Osaka", DiseaseColour.Red));
                _locations.Add(new Location("Tokyo", DiseaseColour.Red));
                _locations.Add(new Location("Shanghai", DiseaseColour.Red));
                _locations.Add(new Location("Beijing", DiseaseColour.Red));
                _locations.Add(new Location("Seoul", DiseaseColour.Red));
            }
            return _locations;
        }
    }
}
