using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class FrameWidget : ControlBase
    {
        public FrameWidget(Composite parent)
            : base(parent)
        {
        }

        public override void Render()
        {
            Screen.WriteFrame(Width, Height); 
        }
    }
}
