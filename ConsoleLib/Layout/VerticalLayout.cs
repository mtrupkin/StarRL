using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class VerticalLayout : LayoutBase<VerticalLayoutData>
    {
        public bool GrabHorizontal { get; set; }

        public override void LayoutControls(Composite composite)
        {
            Height = MinHeight;
            Width = MinWidth;

            int maxWidth = MinWidth;
            int maxHeight = 0;

            if (GrabHorizontal)
            {
                maxWidth = composite.Parent.Width;
            }


            foreach (ControlLayout<VerticalLayoutData> controlLayout in ControlLayouts)
            {
                Control control = controlLayout.Control;

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

            foreach (ControlLayout<VerticalLayoutData> controlLayout in ControlLayouts)
            {
                if (controlLayout.LayoutData.HorizontalJustify == HorizontalJustify.Right)
                {
                    Control control = controlLayout.Control;

                    control.X = Width - control.Width;
                }
            }

        }
    }
}
