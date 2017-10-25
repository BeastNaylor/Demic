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

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            
            Location otherLoc = (Location)obj;
            return (this.Name == otherLoc.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
