using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Ship : Entity
    {
        Char Category { get; set; }

        public override Point Acceleration()
        {
            return Point.ZERO;
        }

    }
}
