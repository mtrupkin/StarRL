using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class StackedLayoutManager : LayoutBase
    {     
        public override void LayoutControls(List<Control> controls)
        {
            int maxWidth = 0;
            int maxHeight = 0;

            foreach (Control control in controls)
            {
                if (control.Width > maxWidth) {
                    maxWidth = control.Width;
                }
                if (control.Height > maxHeight)
                {
                    maxHeight = control.Height;
                }
            }

            Width = maxWidth;
            Height = maxHeight;
        }
    }
}
