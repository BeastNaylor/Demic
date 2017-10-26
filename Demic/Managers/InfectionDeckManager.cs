using Demic.Classes;
using Demic.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    class InfectionDeckManager :IInfectionDeckManager
    {
        private List<Location> _drawDeck;
        private List<Location> _discardDeck;
        private List<Location> _redrawDeck;

        public InfectionDeckManager(ILocationManager locationManager)
        {
            _drawDeck = new List<Location>();
            _discardDeck = new List<Location>();
            _redrawDeck = new List<Location>();

            _drawDeck.AddRange(locationManager.GetLocations());
            _drawDeck.ShuffleDeck<Location>();
        }

        public Location DrawCard()
        {
            Location location = null;
            if (_redrawDeck.Any())
            {
                location = _redrawDeck.First();
                _redrawDeck.Remove(location);
            }
            else if(_drawDeck.Any())
            {
                location = _drawDeck.First();
                _drawDeck.Remove(location);
            }
            _discardDeck.Add(location);
            return location;
        }
        public void IntensifyShuffle()
        {
            _discardDeck.ShuffleDeck();
            _redrawDeck.AddRange(_discardDeck);
            _discardDeck.Clear();

        }
    }
}
