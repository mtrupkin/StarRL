using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public abstract class Entity
    {
        public String Name { get; set; }

        public int Radius { get; set; }

        public Point Position { get; set; }
        public Point Velocity { get; set; }

        public virtual Point Acceleration()
        {
            return Point.ZERO;
        }

    }
}
