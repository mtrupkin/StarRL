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

            LayoutControls();
        }


        protected override void CompactControls()
        {
            Height = MinHeight;
            Width = MinWidth;

            int maxWidth = 0;
            int maxHeight = 0;

            foreach (HorizontalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                controlLayout.X = maxWidth;

                maxWidth += control.Width;

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
