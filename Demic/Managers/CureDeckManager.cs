using Demic.Classes;
using Demic.Enums;
using Demic.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demic.Managers
{
    internal class CureDeckManager : ICureDeckManager
    {
        private List<Location> _deck;
        private List<Location> _discard;

        public CureDeckManager(ILocationManager locationManager)
        {
            _deck = new List<Location>();
            _discard = new List<Location>();

            _deck.AddRange(locationManager.GetLocations());
            _deck.ShuffleDeck();
        }

        public Location DrawCard()
        {
            Location drawCard = null;
            if (_deck.Any())
            {
                drawCard = _deck.First();
                _deck.Remove(drawCard);
            }
            return drawCard;
        }
    }
}
