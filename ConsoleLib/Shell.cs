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
