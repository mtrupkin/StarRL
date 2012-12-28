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

            LayoutControls();
        }

        protected override void CompactControls()
        {
            Height = MinHeight;
            Width = MinWidth;

            int maxWidth = MinWidth;
            int maxHeight = 0;


            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                controlLayout.Y = maxHeight;

                maxHeight += control.Height;


                if (control.Width > maxWidth)
                {
                    maxWidth = control.Width;
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

            foreach (VerticalLayoutData controlLayout in ControlData)
            {
                if (controlLayout.HorizontalJustify == HorizontalJustify.Right)
                {
                    Control control = controlLayout.Control;

                    controlLayout.X = Width - control.Width;
                }
            }

        }
    }    
}
