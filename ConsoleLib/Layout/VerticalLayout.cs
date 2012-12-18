using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class VerticalLayout : LayoutBase
    {
        public override void LayoutControls(List<Control> controls)
        {
            Height = MinHeight;
            Width = MinWidth;

            int maxWidth = MinWidth;
            int maxHeight = 0;

            foreach (Control control in controls)
            {
                control.Y = maxHeight;

                maxHeight += control.Height;

                if (control.Width > maxWidth)
                {
                    maxWidth = control.Width;
                }
            }

            if (maxHeight > MinHeight)
            {
                Height = maxHeight;
            }

            if (maxWidth > MinWidth)
            {
                Width = maxWidth;
            }
        }
    }
}
