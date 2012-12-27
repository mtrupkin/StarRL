using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class HorizontalLayout : LayoutBase<HorizontalLayoutData>
    {
        public override void LayoutControls(Composite parent)
        {
            Height = MinHeight;
            Width = MinWidth;

            int maxWidth = 0;
            int maxHeight = 0;

            foreach (ControlLayout<HorizontalLayoutData> controlLayout in ControlLayouts)
            {
                Control control = controlLayout.Control;

                control.X = maxWidth;

                maxWidth += control.Width;

                if (control.Height > maxHeight)
                {
                    maxHeight = control.Height;
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
