using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class BoxWidget : DecoratorWidget
    {
        public String Title { get; set; }

        public BoxWidget(Control control, String title)
            : base(control, control.Width +2, control.Height+2) 
        {
            Title = title;
            Control.X = 1;
            Control.Y = 1;
        }
        
        public override void Render()
        {
            Screen.SetPosition(0, 0);
            Screen.WriteFrame(Width, Height, Title);

            Control.Render();
            Screen.Display(Control.X, Control.Y, Control.Screen);

        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            var mouseInControl = Control.GetMouseInControl(mouse);
            Control.OnMouseMove(mouseInControl);            
        }

        public override void OnMouseButton(Mouse mouse)
        {
            base.OnMouseButton(mouse);

            var mouseInControl = Control.GetMouseInControl(mouse);
            Control.OnMouseButton(mouseInControl);            
        }
    }
}
