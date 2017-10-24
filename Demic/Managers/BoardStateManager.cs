using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demic.Enums;
using Demic.Classes;

namespace Demic.Managers
{
    internal class BoardStateManager
    {
        private IDictionary<Location, IDictionary<DiseaseColour, int>> _boardLocations;
        private int _outbreakCount;
        ILocationManager _locationManager;

        public int totalCubes(DiseaseColour disease)
        {
            //sum up the cubes of the given disease
            var count = _boardLocations.SelectMany(loc => loc.Value.Where(dis => dis.Key == disease).Select(dis => dis.Value)).Sum();
            return count;
        }

        public BoardStateManager(ILocationManager locationManager)
        {
            _outbreakCount = 0;
            _locationManager = locationManager;
            _boardLocations = new Dictionary<Location, IDictionary<DiseaseColour, int>>();
            foreach (Location location in _locationManager.GetLocations())
            {
                IDictionary<DiseaseColour, int> cubeCounts = new Dictionary<DiseaseColour, int>();
                foreach (DiseaseColour colour in Enum.GetValues(typeof(DiseaseColour)))
                {
                    cubeCounts.Add(colour, 0);
                }
                _boardLocations.Add(location, cubeCounts);
            }

        }

        public void AddCubes(Location loc, int numCubes)
        {
            var cubes = _boardLocations.Where(key => key.Key.ToString() == loc.ToString()).Single();
            cubes.Value[loc.Colour] += numCubes;
        }

        //check the different conditions for failure
        public bool CheckLossConditions()
        {
            bool loss = false;
            if (_outbreakCount > Properties.Settings.Default.MAX_OUTBREAK_COUNT)
            {
                loss = true;
            }
            foreach (DiseaseColour colour in Enum.GetValues(typeof(DiseaseColour)))
            {
                if (this.totalCubes(colour) > Properties.Settings.Default.MAX_DISEASE_CUBES)
                {
                    loss = true;
                }
            }
            return loss;
        }

    }
}
