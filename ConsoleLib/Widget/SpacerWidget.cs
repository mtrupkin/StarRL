using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class SpacerWidget : ControlBase
    {
        public SpacerWidget(Composite parent, int width, int height)
            : base(parent)
        {
            Width = width;
            Height = height;
        }

        public override void Render() { }

    }
}
