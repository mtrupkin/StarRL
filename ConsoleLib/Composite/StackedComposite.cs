using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class StackedComposite : CompositeBase<LayoutData>
    {
        public StackedComposite(Composite parent) : base(parent, parent.Width, parent.Height) { }

        public StackedComposite(Composite parent, int width, int height) : base(parent, width, height) { }

        public override void AddControl(Control control)
        {
            var layoutData = new LayoutData(control);

            AddControl(layoutData);
        }

        public void AddControl(LayoutData layoutData)
        {
            ControlData.Add(layoutData);

            LayoutControls();
        }

        public override Size MinimumSize()
        {
            Size minimumSize = new Size(MinWidth, MinHeight);

            int width = 0;
            int height = 0;

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                if (control.Width > width)
                {
                    width = control.Width;
                }
                if (control.Height > height)
                {
                    height = control.Height;
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
    }
}
