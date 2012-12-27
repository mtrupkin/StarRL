using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public interface Layout
    {
        List<Control> Controls { get; }

        int MinWidth { get; }
        int MinHeight { get; }

        int Width { get; }
        int Height { get; }

        void LayoutControls(Composite parent);

        void SetMinSize(int width, int height);

        void AddControl(Control control);
    }
}
