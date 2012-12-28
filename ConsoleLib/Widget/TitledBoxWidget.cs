using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class TitledBoxWidget : BoxWidget
    {
        public String Title { get; set; }

        public TitledBoxWidget(Control control, String title)
            : base(control)
        {
            Title = title;
        }

        public override void Render()
        {
            Screen.SetPosition(0, 0);
            Screen.WriteFrame(Width, Height, Title);

            Control.Render();
            Screen.Display(1, 1, Control.Screen);

        }
    }
}
