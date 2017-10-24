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
        public string Name;
        public DiseaseColour Colour;

        public override string ToString()
        {
            return String.Format("{0} : {1}", Name, Colour.ToString());
        }
    }
}
