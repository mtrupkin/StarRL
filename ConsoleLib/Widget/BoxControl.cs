using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class BoxControl : Control
    {
        public String Title { get; set; }

        public override void Render()
        {            
            Con.SetPosition(0, 0);
            Con.WriteFrame(Con.Width, Con.Height, Title);
        }
    }
}
