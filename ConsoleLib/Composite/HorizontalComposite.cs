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
       
        public override void GrabExcess()
        {
            if (ControlData.Count > 0)
            {
                int totalWidth = 0;
                foreach (LayoutData controlLayout in ControlData)
                {
                    Control control = controlLayout.Control;
                    control.GrabExcess();

                    int width = control.Width;
                    int heigth = control.Height;

                    if (controlLayout.GrabVertical == true)
                    {
                        heigth = Height;
                    }
                    totalWidth += width;
                    control.Resize(width, heigth);
                }

                LayoutData lastLayoutData = ControlData.Last();

                if (lastLayoutData.GrabHorizontal)
                {
                    Control control = lastLayoutData.Control;
                    int width = control.Width;
                    int height = control.Height;
                    totalWidth -= width;
                    width = Width - totalWidth;
                    lastLayoutData.Control.Resize(width, height);
                }
            }
        }
    }
}
