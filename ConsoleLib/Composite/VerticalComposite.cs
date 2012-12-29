using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class VerticalComposite: CompositeBase<VerticalLayoutData>
    {
        public VerticalComposite(Composite parent, int width, int height) : base(parent, width, height) { }

        public void AddControl(Control control, HorizontalJustify justify)
        {
            var layoutData = new VerticalLayoutData(control) { HorizontalJustify = justify };

            AddControl(layoutData);
        }

        public override void AddControl(Control control)
        {
            var layoutData = new VerticalLayoutData(control);

            AddControl(layoutData);
        }

        public void AddControl(VerticalLayoutData layoutData)
        {
            ControlData.Add(layoutData);
        }

        public override Size MinimumSize()
        {
            Size minimumSize = new Size(MinWidth, MinHeight);

            int width = 0;
            int height = 0;

            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                height += control.Height;

                if (control.Width > width)
                {
                    width = control.Width;
                }
            }

            if (height > MinHeight)
            {
                minimumSize.Height = height;
            }

            if (width > MinWidth)
            {
                minimumSize.Width = width;
            }

            return minimumSize;

        }

        public override void LayoutControls()
        {
            int height = 0;

            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                controlLayout.X = 0;
                controlLayout.Y = height;

                height += control.Height;

                if (controlLayout.HorizontalJustify == HorizontalJustify.Right)
                {
                    controlLayout.X = Width - control.Width;
                }
            }
        }

    }    
}
