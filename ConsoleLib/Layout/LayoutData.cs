using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public enum VerticalJustify { None, Top, Center, Bottom };
    public enum HorizontalJustify { None, Left, Center, Right };

    public class LayoutData
    {
        public VerticalJustify VerticalJustify { get; set; }
        public HorizontalJustify HorizontalJustify { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Control Control { get; protected set; }

        private Mouse TempMouse { get; set; }

        public LayoutData(Control control)
        {
            Control = control;
            TempMouse = new Mouse();
        }

        public bool IsMouseInControl(Mouse mouse)
        {
            if (Control.Enabled)
            {
                if ((mouse.X >= X) &&
                     (mouse.Y >= Y) &&
                     (mouse.X < (X + Control.Width)) &&
                     (mouse.Y < (Y + Control.Height)))
                {
                    return true;
                }
            }

            return false;
        }

        public Mouse GetMouseInControl(Mouse mouse)
        {
            TempMouse.SetMouse(mouse);

            TempMouse.X = mouse.X - X;
            TempMouse.Y = mouse.Y - Y;

            return TempMouse;
        }
    }
}
