using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public delegate void KeyPressEventHandler(ConsoleKey key);
    public delegate void MouseEventHandler(Mouse mouse);

    public abstract class ControlBase : Control
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public bool Enabled { get; protected set; }

        public Control Parent { get; protected set; }
                
        public Screen Screen { get; protected set; }

        private Mouse TempMouse { get; set; }
        public Mouse Mouse { get; protected set; }


        public ControlBase(Control parent, int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            Width = width;
            Height = height;
            Enabled = true;
            Mouse = new Mouse();
            TempMouse = new Mouse();

            Parent = parent;
            Screen = Parent.CreateScreen(width, height);
        }

        public virtual Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public abstract void Render();

        public virtual void LayoutControls()
        {
        }

        public virtual void Dispose()
        {
            if (Screen != null)
            {
                Screen.Dispose();
                Screen = null;
                Enabled = false;
            }
        }

        public virtual void Resize(int width, int height)
        {
            // default behavior to only grow widget
            if ((width > Width) || (height > Height))
            {
                Screen.Dispose();
                Screen = Parent.CreateScreen(width, height);
            }
            Width = width;
            Height = height;
        }

        public virtual void SetEnabled(bool enabled)
        {
            Enabled = enabled;
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
            Mouse.SetMouse(mouse);

            if (MouseMoveEvent != null)
            {
                MouseMoveEvent(mouse);
            }
        }

        public virtual void OnMouseButton(Mouse mouse)
        {
            Mouse.SetMouse(mouse);

            if (MouseButtonEvent != null)
            {
                MouseButtonEvent(mouse);
            }
        }

        public bool IsMouseInControl(Mouse mouse)
        {
            if (Enabled)
            {
                if ((mouse.X >= X) &&
                     (mouse.Y >= Y) &&
                     (mouse.X < (X + Width)) &&
                     (mouse.Y < (Y + Height)))
                {
                    return true;
                }
            }

            return false;
        }

        public Mouse GetMouseInControl(Mouse mouse)
        {
            TempMouse.SetMouse(mouse);

            TempMouse.X = mouse.X - X;
            TempMouse.Y = mouse.Y - Y;

            return TempMouse;
        }
    }    
}
