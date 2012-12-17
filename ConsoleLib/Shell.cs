using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class Shell : Control
    {
        public string Title { get; protected set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public bool Enabled { get; protected set; }
        public Mouse Mouse { get; protected set; }

        public Control Parent { get; protected set; }
        public Screen Screen { get; protected set; }

        
        public abstract void Resize(int width, int height);        

        public event KeyPressEventHandler KeyPressEvent;
        public event MouseEventHandler MouseMoveEvent;
        public event MouseEventHandler MouseButtonEvent;

        public Control MainControl { get; protected set; }

        public Shell(string title, int width, int height)
        {
            Title = title;

            Width = width;
            Height = height;
            Enabled = true;
            Mouse = new Mouse();
        }

        public virtual void Render()
        {
            MainControl.Render();
            Screen.Display(MainControl.X, MainControl.Y, MainControl.Screen);
        }

        public abstract Screen CreateScreen(int width, int height);

        public abstract bool isClosed();

        public void SetMainControl(Control mainControl)
        {
            MainControl = mainControl;
        }

        public virtual void SetEnabled(bool enabled)
        {
            Enabled = enabled;
        }

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

            MainControl.Dispose();
        }

        public void OnKeyPress(ConsoleKey consoleKey)
        {
            if (KeyPressEvent != null)
            {
                KeyPressEvent(consoleKey);
            }

            MainControl.OnKeyPress(consoleKey);
        }

        public void OnMouseMove(Mouse mouse)
        {
            Mouse.SetMouse(mouse);

            if (MouseMoveEvent != null)
            {
                MouseMoveEvent(mouse);
            }

            MainControl.OnMouseMove(mouse);
        }

        public void OnMouseButton(Mouse mouse)
        {
            Mouse.SetMouse(mouse);

            if (MouseButtonEvent != null)
            {
                MouseButtonEvent(mouse);
            }

            MainControl.OnMouseButton(mouse);
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
            return mouse;
        }
    }
}
