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

                Size size = control.CompactSize();

                if (controlLayout.GrabHorizontal)
                {
                    size.Width = Width;
                }

                if (controlLayout.GrabVertical)
                {
                    size.Height = Height;
                }

                control.Resize(size.Width, size.Height);
                               

                control.Align();

                control.Layout();
            }

            //Screen.Clear();
        }
 
        public override void Render()
        {
            var enabledControls = new List<LayoutData>();

            foreach (LayoutData layoutData in ControlData)
            {
                Control control = layoutData.Control;
                if (control.Enabled)
                {
                    enabledControls.Add(layoutData);
                }
                else
                {
                    //control.Screen.Clear();
                    //Screen.Display(layoutData.X, layoutData.Y, control.Screen);
                }
            }

            foreach (LayoutData layoutData in enabledControls)
            {
                Control control = layoutData.Control;
                control.Render();
                Screen.Display(layoutData.X, layoutData.Y, control.Screen);
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
            int width = 1;
            int height = 1;

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                if (control.Enabled)
                {
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
            }

            Resize(width, height);

            return new Size(width, height);
        }       

        public override void Align()
        {
            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                control.Align();

                if (controlLayout.HorizontalJustify == HorizontalJustify.Center)
                {
                    int margin = Width - control.Width;
                    controlLayout.X = (int)( margin / 2);
                }

                if (controlLayout.VerticalJustify == VerticalJustify.Center)
                {
                    int margin = Height - control.Height;
                    controlLayout.Y = (int)(margin / 2);
                }
            }
        }


    }
}
