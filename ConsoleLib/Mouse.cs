using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class Mouse
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool LeftButton { get; set; }
        public bool MiddleButton { get; set; }
        public bool RightButton { get; set; }
        public int PixelX { get; set; }
        public int PixelY { get; set; }

        public void SetMouse(Mouse newMouse)
        {
            X = newMouse.X;
            Y = newMouse.Y;
            LeftButton = newMouse.LeftButton;
            MiddleButton = newMouse.MiddleButton;
            RightButton = newMouse.RightButton;
            PixelX = newMouse.PixelX;
            PixelY = newMouse.PixelY;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Mouse mouse = obj as Mouse;
            if ((X == mouse.X) && (Y == mouse.Y) &&
                (LeftButton == mouse.LeftButton) &&
                (MiddleButton == mouse.MiddleButton) &&
                (RightButton == mouse.RightButton))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public override int GetHashCode()
        {
            return X * Y;
        }
    }
}
