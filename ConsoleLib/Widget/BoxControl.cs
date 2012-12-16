using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class BoxControl : Control
    {
        public String Title { get; protected set; }

        public BoxControl(Composite parent, String title, int width, int height)
            : base(parent, width, height)
        {
            Title = title;
        }
        
        public override void Render()
        {            
            Screen.SetPosition(0, 0);
            Screen.WriteFrame(Width, Height, Title);
        }
    }
}
