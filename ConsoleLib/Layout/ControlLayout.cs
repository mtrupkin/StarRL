using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class ControlLayout <T> where T : LayoutData
    {
        public Control Control {get; protected set;}
        public T LayoutData { get; protected set; }

        public ControlLayout(Control control, T layoutData)
        {
            Control = control;
            LayoutData = layoutData;
        }
    }
}
