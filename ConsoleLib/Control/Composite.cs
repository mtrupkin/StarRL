using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{ 

    public interface Composite : Control
    {

        Screen CreateScreen(int width, int height);

        void AddControl(Control control);

        void SetLayoutManager(Layout layout);

        void LayoutControls();
    }
}
