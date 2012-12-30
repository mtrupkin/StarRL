using System;
using ConsoleLib;
using Flagship;

namespace StarRL.Widget
{
    public class PointWidget : ControlBase
    {
        public Point Point { get; protected set; }

        public PointWidget(Composite parent) : base(parent)
        {
            Point = new Point();

            Resize(7, 1);
            Resize();
        }

        public override void Render()
        {
            if (Point != null)
            {
                Screen.Write(String.Format("[{0,2}.{1,2}]", Point.X, Point.Y));
            }
        }

        public void SetPoint(Point point)
        {
            Point.Set(point);
        }
    }
}
