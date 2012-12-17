using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public class CompositeBase : AbstractComposite, Composite
    {

        public CompositeBase(Composite parent, int width, int height)
            : base(width, height)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            Parent = parent;
            Screen = Parent.CreateScreen(width, height);
        }

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }
                    
        public override void Render()
        {
            foreach (Control control in Controls)
            {
                if (control.Enabled)
                {
                    control.Render();
                    Screen.Display(control.X, control.Y, control.Screen);
                }
            }
        }

        public override void Resize(int width, int height)
        {
            // default behavior to only grow widget
            if ((width > Width) || (height > Height))
            {
                Screen.Dispose();
                Screen = Parent.CreateScreen(width, height);
            }
            Width = width;
            Height = height;
        }
    }
}
