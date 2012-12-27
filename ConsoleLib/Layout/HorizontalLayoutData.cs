using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public enum HorizontalJustify { None, Left, Center, Right };

    public class HorizontalLayoutData : LayoutData
    {
        public HorizontalJustify HorizontalJustify { get; set; }
        public bool HorizontalGrab { get; set; }
    }
}
