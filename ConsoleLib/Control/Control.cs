using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public delegate void KeyPressEventHandler(ConsoleKey key);
    public delegate void MouseEventHandler(Mouse mouse);

    public abstract class Control 
    {
        public int Height { get; set; }
        public int Width { get; set; }
        

        public bool Enabled { get; set; }

        public Composite Parent { get; protected set; }
                
        public Screen Screen { get; protected set; }

        public Mouse Mouse { get; set; }

        protected Control(int width, int height)
        {
            Width = width;
            Height = height;
            Enabled = true;
            Mouse = new Mouse();
        }

        public Control(Composite parent, int width, int height):this(width, height)
        {
            Parent = parent;
            Screen = Parent.CreateScreen(width, height);
        }

        public abstract void Render();

        public virtual void Dispose()
        {
            if (Screen != null)
            {
                Screen.Dispose();
                Screen = null;
                Enabled = false;
            }
        }

        public event KeyPressEventHandler KeyPressEvent;
        public event MouseEventHandler MouseMoveEvent;
        public event MouseEventHandler MouseButtonEvent;

        public virtual void OnKeyPress(ConsoleKey consoleKey)
        {
            if (KeyPressEvent != null)
            {
                KeyPressEvent(consoleKey);
            }
        }

        public virtual void OnMouseMove(Mouse mouse)
        {
            Mouse.X = mouse.X;
            Mouse.Y = mouse.Y;

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
