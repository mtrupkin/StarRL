using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class BoxWidget : ControlCommon
    {
        //public override int Width { get { return Control.Width + 2; } }
        //public override int Height { get { return Control.Height + 2; } }

        public override Composite Parent { get { return Control.Parent; } }

        LayoutData LayoutData { get; set; }
        Control Control { get; set; }
        int Margin { get; set; }

        int Offset { get { return Margin + 1; } }

        public BoxWidget(Control control)
            : this(control, 0)
        {

        }
        public BoxWidget(Control control, int margin)
            : base()
        {
            Control = control;
            Screen = CreateScreen(1, 1);
            LayoutData = new LayoutData(Control);
            Margin = margin;
            LayoutData.X = Offset;
            LayoutData.Y = Offset;
            
        }

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public override void Resize()
        {
            Parent.Resize();
        }

        public override void Render()
        {
            if (Control.Enabled)
            {
                Screen.BackgroundColor = ConsoleRGB.Black;
                Screen.ForegroundColor = ConsoleRGB.Base1;
                Screen.WriteFrame(Width, Height);
                Control.Render();
                Screen.Display(Offset, Offset, Control.Screen);
              
               
                //Screen.WriteFrame(Control.Width + (Offset * 2), Control.Height + (Offset * 2));
                
            }
        }

        public override void Dispose()
        {
            Control.Dispose();
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            Control.OnKeyPress(consoleKey);
        }

        public override void OnMouseMove(Mouse mouse)
        {
            if (LayoutData.IsMouseInControl(mouse))
            {
                var mouseInControl = LayoutData.GetMouseInControl(mouse);
                Control.OnMouseMove(mouseInControl);
            }
        }

        public override void OnMouseButton(Mouse mouse)
        {
            if (LayoutData.IsMouseInControl(mouse))
            {
                var mouseInControl = LayoutData.GetMouseInControl(mouse);
                Control.OnMouseButton(mouseInControl);
            }
        }

        public override Size Compact()
        {
            Size compactSize = Control.Compact();
            compactSize.Width += Offset * 2;
            compactSize.Height += Offset * 2;

            Resize(compactSize);

            return compactSize;
        }

        public override void Align()
        {
            Control.Align();
        }

        public override void GrabExcess(Size excess)
        {
            
            int width = Width;
            int height = Height;

            if (GrabHorizontal)
            {
                width = excess.Width;
            }

            if (GrabVertical)
            {
                height = excess.Height;
            }

            Resize(width, height);

            Control.GrabExcess(new Size(width - (Offset * 2), height - (Offset * 2)));
        }
    

        public override void Resize(int width, int height)
        {
            base.Resize(width , height );
            Control.Resize(width- (Offset*2), height-(Offset*2));
        }
        
    
        
    }
}
