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
            : base()
        {
            Title = title;

            Width = width;
            Height = height;
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
            AddControl(layoutData);
        }

        public void AddControl(LayoutData layoutData)
        {
            ControlData.Add(layoutData);
        }

        public override void Resize()
        {
            Screen.Clear();
            Layout();
        }
     
    }
}
