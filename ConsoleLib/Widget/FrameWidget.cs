using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib.Widget
{
    public class FrameWidget : ControlBase
    {
        public FrameWidget(Composite parent, int width, int height)
            : base(parent)
        {
            Width = width;
            Height = height;
        }

        public override void Render()
        {
            Screen.WriteFrame(Width, Height); 
        }

        public override void GrabExcess(Size excess)
        {

            int width = Width;
            int heigth = Height;

            if (GrabHorizontal)
            {
                width = excess.Width;
            }

            if (GrabVertical)
            {
                heigth = excess.Height;
            }

            Resize(width, heigth);
        }

        public override void Resize(int width, int height)
        {
            base.Resize(width, height);
        }
    }
}
