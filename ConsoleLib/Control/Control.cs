using System;

namespace ConsoleLib
{

    public interface Control : IDisposable
    {
        int X { get; set; }
        int Y { get; set; }

        int Height { get; }
        int Width { get; }

        bool Enabled { get; }
        Mouse Mouse { get; }

        Control Parent { get; }
        Screen Screen { get; }

        void Resize(int width, int height);
        void SetEnabled(bool enabled);

        void Render();        
        Screen CreateScreen(int width, int height);

        event KeyPressEventHandler KeyPressEvent;
        event MouseEventHandler MouseMoveEvent;
        event MouseEventHandler MouseButtonEvent;

        void OnKeyPress(ConsoleKey consoleKey);
        void OnMouseMove(Mouse mouse);
        void OnMouseButton(Mouse mouse);

        bool IsMouseInControl(Mouse mouse);
        Mouse GetMouseInControl(Mouse mouse);

        // ???
        void LayoutControls();
    }    
}
