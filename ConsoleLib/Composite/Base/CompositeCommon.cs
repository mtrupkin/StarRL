using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class CompositeCommon<T> : ControlCommon, Composite where T:LayoutData
    {
        public List<T> ControlData { get; protected set; }        

        public CompositeCommon()
  
        {
            ControlData = new List<T>();
            Width = 1;
            Height = 1;
        }

        public abstract void AddControl(Control control);

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public override void Resize()
        {
            Parent.Resize();
        }

        public override void Layout()
        {
            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                Size compactSize = control.CompactSize();

                if (controlLayout.GrabExcess)
                {
                    control.Resize(Width, compactSize.Height);
                }
                else
                {
                    control.Resize(compactSize.Width, compactSize.Height);
                }                 

                control.Align();
                control.Layout();
            }

            //Screen.Clear();
        }
 
        public override void Render()
        {
            foreach (LayoutData layoutData in ControlData)
            {
                Control control = layoutData.Control;
                if (control.Enabled)
                {
                    control.Render();
                    Screen.Display(layoutData.X, layoutData.Y, control.Screen);
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

        public override Size CompactSize()
        {
            int width = 0;
            int height = 0;

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                Size compactSize = control.CompactSize();

                if (compactSize.Width > width)
                {
                    width = compactSize.Width;
                }
                if (compactSize.Height > height)
                {
                    height = compactSize.Height;
                }
            }

            return new Size(width, height);
        }

        public override void Align()
        {
            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                control.Align();
            }
        }

    }
}
