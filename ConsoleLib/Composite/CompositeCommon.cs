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

                control.Compact();

            }

            foreach (LayoutData controlLayout in ControlData)
            {
               Control control = controlLayout.Control;

               control.GrabExcess(new Size(Width, Height));

            }

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;

                //control.GrabExcess();

                control.Align();

                //control.Layout();
            }
            //foreach (LayoutData controlLayout in ControlData)
            //{
            //    Control control = controlLayout.Control;

            //    //control.GrabExcess();

            //    //control.Align();

            //    control.Layout();
            //}
            //Screen.Clear();
        }

        public override Size Compact()
        {
            int width = 1;
            int height = 1;

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;
                if (control.Enabled)
                {
                    Size compactSize = control.Compact();

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
                    controlLayout.X = (int)(margin / 2);
                }
                else if (controlLayout.HorizontalJustify == HorizontalJustify.Right)
                {
                    controlLayout.X = Width - control.Width;
                }

                if (controlLayout.VerticalJustify == VerticalJustify.Center)
                {
                    int margin = Height - control.Height;
                    controlLayout.Y = (int)(margin / 2);
                }
                else if (controlLayout.VerticalJustify == VerticalJustify.Bottom)
                {
                    controlLayout.Y = Height - control.Height;
                }
            }
        }

        public override void GrabExcess(Size excess)
        {
            int width = Width;
            int heigth = Height;

            if (GrabHorizontal)
            {
                width = excess.Width;
            }

            if (GrabVertical)
            {
                heigth = excess.Height;
            }

            Resize(width, heigth);

            foreach (LayoutData controlLayout in ControlData)
            {
                Control control = controlLayout.Control;


                control.GrabExcess(excess);

            }
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
                if ((control.Width > 1) && (control.Height > 1))
                {
                    //control.Screen.WriteFrame(control.Width, control.Height);
                }
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

    }
}
