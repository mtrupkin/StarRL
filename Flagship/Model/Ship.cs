using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Ship : MovableEntity
    {
        public Char Category { get; set; }
		
		public int Shields { get; set; }
        public int Hull { get; set; }
		public int Torpedoes { get; set; }
		public int Phasers { get; set; }
		public int Scanners { get; set; }

        public Ship()
        {
            EntityType = EntityTypeEnum.Ship;
        }

        public override Point Acceleration()
        {
            return Point.ZERO;
        }

    }
}
