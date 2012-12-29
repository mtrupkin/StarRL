using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{ 

    public interface Composite : Control 
    {
        Mouse Mouse { get; }        

        int MinWidth { get; }
        int MinHeight { get; }

        Screen CreateScreen(int width, int height);

        void AddControl(Control control);

        Size MinimumSize();
        void Resize();
 
        void LayoutControls();
    }
}
