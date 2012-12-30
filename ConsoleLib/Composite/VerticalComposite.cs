using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class VerticalComposite: CompositeBase<VerticalLayoutData>
    {
        public VerticalComposite(Composite parent) : base(parent) { }

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

        public override Size CompactSize()
        {
            int width = 0;
            int height = 0;

            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                Size compactSize = control.CompactSize();

                height += compactSize.Height;

                if (compactSize.Width > width)
                {
                    width = compactSize.Width;
                }
            }

            return new Size(width, height);
        }

        public override void Align()
        {
            int height = 0;

            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                control.Align();

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
