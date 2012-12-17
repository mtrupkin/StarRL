using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{ 

    public interface Composite : Control
    {                            
        void SetLayoutManager(Layout layout);

        void AddControl(Control control);

        void RemoveControl(Control control);

    }
}
