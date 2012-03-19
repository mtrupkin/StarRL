using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public interface Screen : IDisposable
    {
        int Height { get; set; }
        int Width { get; set; }

        void Clear();

        ConsoleRGB ForegroundColor { get; set; }

        ConsoleRGB BackgroundColor { get; set; }        

        void SetPosition(int x, int y);

        void Write(char c);

        void Write(string s);

        void WriteFrame(int width, int height);

        void WriteFrame(int width, int height, String title);

        void Display(int x, int y, Screen console);
    }
}
