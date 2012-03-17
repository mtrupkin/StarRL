using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class LayoutManager
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<Control> Controls { get; set; }

        public LayoutManager()
        {
            Controls = new List<Control>();
        }

        public virtual void AddControl(Control control)
        {
            if (control != null)
            {
                Controls.Add(control);
            }
        }

        public virtual List<ControlLayout> GetLayouts()
        {
            List<ControlLayout> layouts = new List<ControlLayout>();
            int lastY = this.Y;

            foreach (Control control in Controls)
            {
                ControlLayout layout = new ControlLayout()
                {
                    X = this.X,
                    Y = lastY,
                    Control = control
                };

                layouts.Add(layout);

                lastY += control.Height;
            }

            return layouts;
        }
    }
}
