using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class HorizontalLayout : Layout
    {
        public void LayoutControls(List<Control> controls)
        {
            int lastX = 0;

            foreach (Control control in controls)
            {
                control.X = lastX;

                lastX += control.Width;
            }
        }
    }
}
