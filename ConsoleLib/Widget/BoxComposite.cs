using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class BoxComposite : CompositeBase
    {
        public BoxComposite(Composite parent, int width, int height)
            : base(parent, width+2, height+2)
        {
        }

        public override void Render()
        {
            Screen.SetPosition(0, 0);
            Screen.WriteFrame(Width, Height);

            foreach (Control control in Controls)
            {
                if (control.Enabled)
                {
                    control.Render();
                    Screen.Display(control.X+1, control.Y+1, control.Screen);
                }
            }
        }

        public override void Resize(int width, int height)
        {
            base.Resize(width+2, height+2);
        }
        
    }
}
