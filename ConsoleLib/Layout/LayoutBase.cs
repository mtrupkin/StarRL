using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class LayoutBase : Layout
    {
        public int MinWidth { get; protected set; }
        public int MinHeight { get; protected set; }

        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public abstract void LayoutControls(List<Control> controls);

        public void SetMinSize(int width, int height)
        {
            MinWidth = width;
            MinHeight = height;
        }
    }
}
