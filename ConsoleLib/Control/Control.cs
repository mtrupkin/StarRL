using System;

namespace ConsoleLib
{
    public delegate void KeyPressEventHandler(ConsoleKey key);
    public delegate void MouseEventHandler(Mouse mouse);

    public interface Control : IDisposable
    {
        int Height { get; }
        int Width { get; }

        bool Enabled { get; }

        Composite Parent { get; }
        Screen Screen { get; }
       
        void Resize(int width, int height);
        void SetEnabled(bool enabled);

        void Render();        

        event KeyPressEventHandler KeyPressEvent;
        event MouseEventHandler MouseMoveEvent;
        event MouseEventHandler MouseButtonEvent;

        void OnKeyPress(ConsoleKey consoleKey);
        void OnMouseMove(Mouse mouse);
        void OnMouseButton(Mouse mouse);
    }    
}
