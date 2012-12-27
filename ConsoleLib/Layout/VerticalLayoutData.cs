using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public enum VerticalJustify { None, Top, Center, Bottom };

    public class VerticalLayoutData : LayoutData
    {
        public HorizontalJustify HorizontalJustify { get; set; }
    }
}
