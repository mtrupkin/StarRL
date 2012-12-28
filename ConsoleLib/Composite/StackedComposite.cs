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

        protected override void CompactControls()
        {
            Height = MinHeight;
            Width = MinWidth;

            int maxWidth = 0;
            int maxHeight = 0;

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                if (control.Width > maxWidth)
                {
                    maxWidth = control.Width;
                }
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
