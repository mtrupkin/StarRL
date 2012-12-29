using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class Shell : CompositeCommon<LayoutData>
    {
        public string Title { get; protected set; }

        public Shell(string title, int width, int height)
            : base(width, height)
        {
            Title = title;
        }

        public abstract bool isClosed();

        public override void Dispose()
        {
            base.Dispose();

            if (Screen != null)
            {
                Screen.Dispose();
                Screen = null;
                Enabled = false;
            }
        }

        public override void AddControl(Control control)
        {
            var layoutData = new LayoutData(control);

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
