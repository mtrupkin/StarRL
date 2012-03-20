using System;
using ConsoleLib;
using Flagship;

namespace StarRL.Widget
{
    public class PointWidget : Control
    {
        public Point Point { get; protected set; }

        public PointWidget()
        {
            Point = new Point();
            Width = 7;
            Height = 1;
        }

        public override void Render()
        {
            //Con.Clear();

            if (Point != null)
            {
                Con.Write(String.Format("[{0,2}.{1,2}]", Point.X, Point.Y));
            }
        }

        public void SetPoint(Point point)
        {
            Point.Set(point);
        }
    }
}
