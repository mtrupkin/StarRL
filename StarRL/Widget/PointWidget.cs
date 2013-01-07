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

            Resize(9, 1);
            Resize();
        }

        public override void Render()
        {
            if (Point != null)
            {
                String text = String.Format("[{0,3}.{1,3}]", Point.X, Point.Y);
                

                Screen.Write(text);
            }
        }

        public void SetPoint(Point point)
        {
            Point.Set(point);
        }
    }
}
