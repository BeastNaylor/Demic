using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demic.Enums;

namespace Demic.Classes
{
    class Location
    {
        public readonly string Name;
        public readonly DiseaseColour Colour;

        public Location(string name, DiseaseColour colour)
        {
            this.Name = name;
            this.Colour = colour;
        }

        public override string ToString()
        {
            return String.Format("{0} : {1}", Name, Colour.ToString());
        }
    }
}
