using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class ControlCommon : Control
    {

        public virtual int Width { get; protected set; }
        public virtual int Height { get; protected set; }       

        public bool Enabled { get; protected set; }

        public Composite Parent { get; protected set; }                
        public Screen Screen { get; protected set; }

        public ControlCommon(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            Width = width;
            Height = height;
            Enabled = true;
        }

        public abstract void Render();

        public abstract void Resize(int width, int height);

        public abstract void Dispose();

        public virtual void SetEnabled(bool enabled)
        {
            Enabled = enabled;
        }

        public event KeyPressEventHandler KeyPressEvent;
        public event MouseEventHandler MouseMoveEvent;
        public event MouseEventHandler MouseButtonEvent;

        public virtual Size MinimumSize() { return new Size(Width, Height); }
 
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
