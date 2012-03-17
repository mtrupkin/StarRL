using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Point
    {
        public static Point ZERO = new Point();

        public int X { get; set; }

        public int Y { get; set; }
        
        public Point()
        {
        }

        public Point(Point newLocation)
        {
            Set(newLocation);
        }


        public Point(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public Point Set(Point newLocation)
        {
            X = newLocation.X;
            Y = newLocation.Y;
            return this;
        }


        public Point Set(int newX, int newY)
        {
            X = newX;
            Y = newY;
            return this;
        }

        public Point Add(Point loc)
        {
            X += loc.X;
            Y += loc.Y;

            return this;
        }

        public Point Subtract(Point loc)
        {
            X -= loc.X;
            Y -= loc.Y;

            return this;
        }

        public override int GetHashCode()
        {
            return X * Y;
        }

        public override bool Equals(object obj)
        {
            Point loc = obj as Point;
            if (loc != null)
            {
                if ((X == loc.X) && (Y == loc.Y))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return X + " " + Y;
        }
    }
}
