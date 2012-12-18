using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public interface Layout
    {
        int MinWidth { get; }
        int MinHeight { get; }

        int Width { get; }
        int Height { get; }

        void LayoutControls(List<Control> controls);

        void SetMinSize(int width, int height);
    }
}
