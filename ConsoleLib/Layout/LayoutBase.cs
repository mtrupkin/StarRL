using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class LayoutBase<T> : Layout where T : LayoutData, new()
    {
        protected List<ControlLayout<T>> ControlLayouts { get; set; }

        public List<Control> Controls
        {
            get
            {
                var controls = new List<Control>();
                foreach(ControlLayout<T> controlLayout in ControlLayouts) {
                    controls.Add(controlLayout.Control);
                }
                return controls;
            }
        }

        public int MinWidth { get; protected set; }
        public int MinHeight { get; protected set; }

        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public LayoutBase()
        {
            ControlLayouts = new List<ControlLayout<T>>();
        }

        public void AddControl(Control control)
        {
            ControlLayouts.Add(new ControlLayout<T>(control, new T()));
        }

        public void AddControl(Control control, T layoutData)
        {
            ControlLayouts.Add(new ControlLayout<T>(control, layoutData));
        }

        public abstract void LayoutControls(Composite parent);

        public void SetMinSize(int width, int height)
        {
            MinWidth = width;
            MinHeight = height;
        }
    }
}
