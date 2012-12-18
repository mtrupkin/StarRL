using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class HorizontalLayout : LayoutBase
    {
        public override void LayoutControls(List<Control> controls)
        {
            int maxWidth = 0;
            int maxHeight = 0;

            foreach (Control control in controls)
            {
                control.X = maxWidth;

                maxWidth += control.Width;

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
