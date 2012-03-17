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
        public Composite Parent { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool Enabled { get; set; }
                
        public IConsole Con { get; set; }

        public Mouse Mouse { get; set; }

        public Control()
        {
            Enabled = true;
            Mouse = new Mouse();
        }

        public abstract void Render();

        public virtual void Initialize(Shell shell)
        {
            if (Con == null)
            {
                Con = shell.CreateConsole(Width, Height);
            }
        }

        public virtual void Dispose()
        {
            if (Con != null)
            {
                Con.Dispose();
                Con = null;
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
