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

        public override Size Compact()
        {
            int width = 0;
            int height = 0;

            foreach (HorizontalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                Size compactSize = control.Compact();

                width += compactSize.Width;

                if (compactSize.Height > height)
                {
                    height = compactSize.Height;
                }
            }

            Resize(width, height);

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

        public override void GrabExcess(Size excess)
        {
            int width = Width;
            int heigth = Height;

            if (GrabHorizontal)
            {
                width = excess.Width;
            }

            if (GrabVertical)
            {
                heigth = excess.Height;
            }

            Resize(width, heigth);

            if (ControlData.Count > 0)
            {
                int totalWidth = 0;
                foreach (LayoutData controlLayout in ControlData)
                {
                    Control control = controlLayout.Control;
                    control.GrabExcess(new Size(control.Width, Height));

                    totalWidth += control.Width;
                }

                LayoutData lastLayoutData = ControlData.Last();
                Control lastControl = lastLayoutData.Control;
                lastControl.GrabExcess(new Size(Width - totalWidth + lastControl.Width , Height));
            }
        }
    }
}
