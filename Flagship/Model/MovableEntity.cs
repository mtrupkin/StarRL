using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public abstract class MovableEntity:Entity
    {
        public Point Velocity { get; set; }

        public virtual Point Acceleration()
        {
            return Point.ZERO;
        }
    }
}
