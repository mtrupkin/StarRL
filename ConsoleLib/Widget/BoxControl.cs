using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class BoxControl : ControlCommon
    {
        //public override int Width { get { return Control.Width + 2; } }
        //public override int Height { get { return Control.Height + 2; } }

        public override Composite Parent { get { return Control.Parent; } }

        LayoutData LayoutData { get; set; }
        Control Control { get; set; }


        public BoxControl(Control control)
            : base()
        {
            Control = control;
            Screen = CreateScreen(1, 1);
            LayoutData = new LayoutData(Control);
            LayoutData.X = 1;
            LayoutData.Y = 1;
        }

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public override void Resize()
        {
            Parent.Resize();
        }

        public override void Render()
        {
            if (Control.Enabled)
            {

                Control.Render();
                Screen.WriteFrame(Control.Width + 2, Control.Height + 2);
                Screen.Display(1, 1, Control.Screen);
                
            }
        }

        public override void Dispose()
        {
            Control.Dispose();
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            Control.OnKeyPress(consoleKey);
        }

        public override void OnMouseMove(Mouse mouse)
        {
            if (LayoutData.IsMouseInControl(mouse))
            {
                var mouseInControl = LayoutData.GetMouseInControl(mouse);
                Control.OnMouseMove(mouseInControl);
            }
        }

        public override void OnMouseButton(Mouse mouse)
        {
            if (LayoutData.IsMouseInControl(mouse))
            {
                var mouseInControl = LayoutData.GetMouseInControl(mouse);
                Control.OnMouseButton(mouseInControl);
            }
        }

        public override void Layout()
        {
            Control.Layout();
        }

        public override Size CompactSize()
        {
            Size compactSize = Control.CompactSize();
            compactSize.Width += 2;
            compactSize.Height += 2;
            return compactSize;
        }

        public override void Align()
        {
            Control.Align();
        }

        public override void Resize(int width, int height)
        {
            base.Resize(width, height);
            Control.Resize(width-2, height-2);
        }
        
    
        
    }
}
