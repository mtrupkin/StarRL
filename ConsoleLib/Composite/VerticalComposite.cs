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

        public override Size Compact()
        {
            int width = 0;
            int height = 0;

            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                Size compactSize = control.Compact();

                height += compactSize.Height;

                if (compactSize.Width > width)
                {
                    width = compactSize.Width;
                }
            }

            Resize(width, height);

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
                if (controlLayout.HorizontalJustify == HorizontalJustify.Center)
                {
                    int margin = Width - control.Width;
                    controlLayout.X = (int)(margin / 2);
                }
            }
        }

        public override void GrabExcess()
        {
            int totalHeight = 0;
            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                control.GrabExcess();

                int width = control.Width;
                int heigth = control.Height;

                if (controlLayout.GrabHorizontal == true)
                {
                    width = Width;
                }
                totalHeight += heigth;
                control.Resize(width, heigth);
            }
            LayoutData lastLayoutData = ControlData.Last();

            if (lastLayoutData.GrabVertical)
            {
                Control control = lastLayoutData.Control;
                int width = control.Width;
                int height = control.Height;
                    totalHeight -= height;
                    height = Height- totalHeight;
                
                lastLayoutData.Control.Resize(width, height);
            }
        }
    }    
}
