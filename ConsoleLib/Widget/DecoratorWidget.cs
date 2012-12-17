using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class DecoratorWidget : ControlBase
    {
        public Control Control { get; protected set; }

        public DecoratorWidget(Control control, int width, int height)
            : base(control.Parent, width, height)
        {
            Control = control;
        }

        public DecoratorWidget(Control control)
            : base(control.Parent, control.Width, control.Height)
        {
            Control = control;
        }

        public override void Render()
        {
            Control.Render();
            Screen.Display(Control.X, Control.Y, Control.Screen);
        }

        public override void Dispose()
        {
            base.Dispose();

            Control.Dispose();
        }        

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            base.OnKeyPress(consoleKey);

            Control.OnKeyPress(consoleKey);
        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            Control.OnMouseMove(mouse);
        }

        public override void OnMouseButton(Mouse mouse)
        {
            base.OnMouseButton(mouse);

            Control.OnMouseButton(mouse);
        }

    }
}
