using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class VerticalLayout : Layout
    {
        public void LayoutControls(List<Control> controls)
        {
            int lastY = 0;

            foreach (Control control in controls)
            {
                control.Y = lastY;

                lastY += control.Height;
            }
        }
    }
}
