using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{ 

    public interface Composite : Control 
    {
        Mouse Mouse { get; }        

        void AddControl(Control control);

        //void LayoutControls();
    }
}
