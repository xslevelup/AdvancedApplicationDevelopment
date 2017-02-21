using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    class SpaceShuttle : IPrintable
    {
        public string Name { get; set; }
        public string FirstFlight { get; set; }

        public SpaceShuttle(string name, string firstFlight)
        {
            Name = name;
            FirstFlight = firstFlight;
        }

        public string Description()
        {
            return string.Format("The {0} first flew on {1}", Name, FirstFlight);
        }

        #region IPrintable interface implementation

        public virtual string Print()
        {
            return Description();
        }

        #endregion
    }
}
