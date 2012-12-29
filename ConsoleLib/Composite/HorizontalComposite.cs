using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class HorizontalComposite: CompositeBase<HorizontalLayoutData>
    {
        public HorizontalComposite(Composite parent, int width, int height) : base(parent, width, height) { }

        public override void AddControl(Control control)
        {
            var layoutData = new HorizontalLayoutData(control);

            AddControl(layoutData);
        }

        public void AddControl(HorizontalLayoutData layoutData)
        {
            ControlData.Add(layoutData);

            Resize();
        }


        public override Size MinimumSize()
        {
            Size minimumSize = new Size(MinWidth, MinHeight);

            int width = 0;
            int height = 0;

            foreach (HorizontalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                width += control.Width;

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

        public override void LayoutControls()
        {
            int width = 0;

            foreach (HorizontalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                controlLayout.Y = 0;
                controlLayout.X = width;

                width += control.Width;
            }

        }
    }
}
