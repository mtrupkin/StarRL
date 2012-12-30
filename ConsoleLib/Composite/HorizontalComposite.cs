using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class HorizontalComposite: CompositeBase<HorizontalLayoutData>
    {
        public HorizontalComposite(Composite parent) : base(parent) { }

        public override void AddControl(Control control)
        {
            var layoutData = new HorizontalLayoutData(control);

            AddControl(layoutData);
        }

        public void AddControl(HorizontalLayoutData layoutData)
        {
            ControlData.Add(layoutData);
        }

        public override Size CompactSize()
        {
            int width = 0;
            int height = 0;

            foreach (HorizontalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                Size compactSize = control.CompactSize();

                width += compactSize.Width;

                if (compactSize.Height > height)
                {
                    height = compactSize.Height;
                }
            }

            return new Size(width, height);
        }

        public override void Align()
        {
            int width = 0;

            foreach (HorizontalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                control.Align();

                controlLayout.Y = 0;
                controlLayout.X = width;

                width += control.Width;
            }

        }
    }
}
