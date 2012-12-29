using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class CompositeCommon<T> : ControlCommon, Composite where T:LayoutData
    {
        public List<T> ControlData { get; protected set; }

        public Mouse Mouse { get; protected set; }

        public int MinWidth { get; protected set; }
        public int MinHeight { get; protected set; }

        public CompositeCommon(int width, int height)
            : base(width, height)
        {
            MinWidth = width;
            MinHeight = height;
            ControlData = new List<T>();
        }

        public abstract Screen CreateScreen(int width, int height);

        public abstract void AddControl(Control control);


        public virtual void Resize()
        {
            Size size = MinimumSize();

            Resize(size.Width, size.Height, true);

            LayoutControls();
        }

        public virtual void LayoutControls()
        {
        }
 
        public override void Render()
        {
            foreach (LayoutData layoutData in ControlData)
            {
                if (layoutData.Control.Enabled)
                {
                    layoutData.Control.Render();
                    Screen.Display(layoutData.X, layoutData.Y, layoutData.Control.Screen);
                }
            }
        }

        public override void Dispose()
        {
            foreach (LayoutData layoutData in ControlData)
            {
                layoutData.Control.Dispose();
            }
        }


        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            base.OnKeyPress(consoleKey);

            foreach (LayoutData layoutData in ControlData)
            {
                Control control = layoutData.Control;
                if (control.Enabled)
                {
                    control.OnKeyPress(consoleKey);
                }
            }
        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            foreach (LayoutData layoutData in ControlData)
            {
                Control control = layoutData.Control;
                if (control.Enabled)
                {
                    if (layoutData.IsMouseInControl(mouse))
                    {
                        var mouseInControl = layoutData.GetMouseInControl(mouse);
                        control.OnMouseMove(mouseInControl);
                    }
                }
            }
        }

        public override void OnMouseButton(Mouse mouse)
        {
            base.OnMouseButton(mouse);

            var eventControls = new List<LayoutData>();

            foreach (LayoutData layoutData in ControlData)
            {
                Control control = layoutData.Control;
                if (control.Enabled)
                {
                    if (layoutData.IsMouseInControl(mouse))
                    {
                        eventControls.Add(layoutData);
                    }
                }
            }

            foreach (LayoutData layoutData in eventControls)
            {
                Control control = layoutData.Control;
                var mouseInControl = layoutData.GetMouseInControl(mouse);

                control.OnMouseButton(mouseInControl);
            }
        }
    }
}
