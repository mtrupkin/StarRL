using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class ControlBase : ControlCommon
    {

        public ControlBase(Composite parent)
            : base()
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            Parent = parent;
            Screen = CreateScreen(1, 1);
        }

        public override void Dispose()
        {
            Screen.Dispose();
            Screen = null;
            Enabled = false;
        }

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public override void Resize()
        {
            Parent.Resize();
        }
    }    
}
