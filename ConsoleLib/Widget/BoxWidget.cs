using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class BoxWidget : DecoratorWidget
    {
        public override int Width { get { return Control.Width + 2; } }
        public override int Height { get { return Control.Height + 2; } }

        protected Mouse TempMouse { get; set; }

        public BoxWidget(Control control)
            : base(control, control.Width+2, control.Height+2) 
        {
            TempMouse = new Mouse();
        }
        
        public override void Render()
        {
            Screen.SetPosition(0, 0);
            Screen.WriteFrame(Control.Width+2, Control.Height+2);            

            Control.Render();
            Screen.Display(1, 1, Control.Screen);

        }

        public override void Resize(int width, int height, bool notify)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            base.Resize(width + 2, height + 2, notify);           
        }

        protected bool IsMouseInControl(Mouse mouse)
        {
            if (Control.Enabled)
            {
                if ((mouse.X >= 1) &&
                     (mouse.Y >= 1) &&
                     (mouse.X < (1 + Control.Width)) &&
                     (mouse.Y < (1 + Control.Height)))
                {
                    return true;
                }
            }

            return false;
        }

        protected Mouse GetMouseInControl(Mouse mouse)
        {
            TempMouse.SetMouse(mouse);

            TempMouse.X = mouse.X - 1;
            TempMouse.Y = mouse.Y - 1;

            return TempMouse;
        }

        public override void OnMouseMove(Mouse mouse)
        {

            if (IsMouseInControl(mouse))
            {
                var mouseInControl = GetMouseInControl(mouse);
                Control.OnMouseMove(mouseInControl);
            }

        }

        public override void OnMouseButton(Mouse mouse)
        {
            if (IsMouseInControl(mouse))
            {
                var mouseInControl = GetMouseInControl(mouse);
                Control.OnMouseButton(mouseInControl);
            }
        }
    }
}
