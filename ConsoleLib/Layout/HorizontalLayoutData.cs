using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{    

    public class HorizontalLayoutData : LayoutData
    {
        public HorizontalJustify HorizontalJustify { get; set; }

        public HorizontalLayoutData(Control control) : base(control) { }
    }
}
