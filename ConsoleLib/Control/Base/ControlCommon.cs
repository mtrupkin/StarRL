using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class ControlCommon : Control
    {

        public bool GrabHorizontal { get; set; }
        public bool GrabVertical { get; set; }

        public  int Width { get; protected set; }
        public  int Height { get; protected set; }       

        public bool Enabled { get; protected set; }

        public virtual Composite Parent { get; protected set; }                
        public Screen Screen { get; protected set; }

        public Mouse Mouse { get; protected set; }

        public ControlCommon()
        {           
            Enabled = true;

            Width = 1;
            Height = 1;

            Mouse = new Mouse();
        }

        public abstract void Render();
        public abstract Screen CreateScreen(int width, int height);
        public abstract void Dispose();

        public virtual void SetEnabled(bool enabled)
        {
            Enabled = enabled;
            Resize();
        }

        public event KeyPressEventHandler KeyPressEvent;
        public event MouseEventHandler MouseMoveEvent;
        public event MouseEventHandler MouseButtonEvent;

        public abstract void Resize();
        public virtual Size Compact() { return new Size(Width, Height);  }
        public virtual void Layout() { }
        public virtual void Align() { }
        public virtual void GrabExcess(Size excess) { }

        public virtual void Resize(Size size)
        {
            Resize(size.Width, size.Height);
        }

        public virtual void Resize(int width, int height)
        {
            //if (width <= 0)
            //{
            //    throw new ArgumentOutOfRangeException("width");
            //}

            //if (height <= 0)
            //{
            //    throw new ArgumentOutOfRangeException("height");
            //}

            if ((width > 0) && (height > 0))
            {
                Screen.Dispose();
                Screen = CreateScreen(width, height);
            }
            Width = width;
            Height = height;
        }

        public virtual void OnKeyPress(ConsoleKey consoleKey)
        {
            if (KeyPressEvent != null)
            {
                KeyPressEvent(consoleKey);
            }
        }

        public virtual void OnMouseMove(Mouse mouse)
        {
            if (MouseMoveEvent != null)
            {
                MouseMoveEvent(mouse);
            }

            Mouse.SetMouse(mouse);
        }

        public virtual void OnMouseButton(Mouse mouse)
        {
            if (MouseButtonEvent != null)
            {
                MouseButtonEvent(mouse);
            }
        }

    }    
}
