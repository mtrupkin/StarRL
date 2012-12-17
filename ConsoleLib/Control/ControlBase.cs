using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class ControlBase : AbstractControl
    {

        public ControlBase(Composite parent, int width, int height) : base(width, height)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            Parent = parent;
            Screen = Parent.CreateScreen(width, height);
        }

        public override void Dispose()
        {
            Screen.Dispose();
            Screen = null;
            Enabled = false;
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
