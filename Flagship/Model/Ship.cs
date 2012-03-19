using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Ship : MovableEntity
    {
        Char Category { get; set; }

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
