using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using libtcod;

namespace Libtcod
{
    public class LibtcodShell : Shell
    {
        ConsoleKey Key { get; set; }        
        Mouse OldMouse { get; set; }

        public LibtcodShell(string title, int width, int height) : base (title, width, height)
        {
            //Mouse = new Mouse();
            OldMouse = new Mouse();

            TCODConsole.initRoot(Width, Height, Title, false, TCODRendererType.SDL);
            TCODConsole.root.setBackgroundColor(TCODColor.black);
            TCODConsole.root.setForegroundColor(TCODColor.white);
            TCODConsole.root.setKeyColor(TCODColor.red);
            TCODConsole.root.clear();
            TCODSystem.setFps(24);

            Screen = new LibtcodScreen(Width, Height, TCODConsole.root);

            TCODConsole.flush();
        }

        public override Screen CreateScreen(int width, int height)
        {
            return new LibtcodScreen(width, height);
        }

        public override void Resize(int width, int height)
        {
            if ((width != Width) || (height != Height)) {
                Width = width;
                Height = height;

                TCODConsole.root.Dispose();

                TCODConsole.initRoot(Width, Height, Title, false, TCODRendererType.SDL);

                Screen = new LibtcodScreen(Width, Height, TCODConsole.root);
            }
        }

        public override void Render()
        {
            base.Render();

            TCODConsole.flush();

            ProcessInput();
        }

        protected void ProcessInput()
        {
        
            TCODMouseData mouse = TCODMouse.getStatus();

            OldMouse.SetMouse(Mouse);
            SetMouse(Mouse, mouse);


            if (!(OldMouse.X == Mouse.X &&
                OldMouse.Y == Mouse.Y))
            {                
                OnMouseMove(Mouse);
            }

            if (!(OldMouse.LeftButton == Mouse.LeftButton))
            {
                if (!Mouse.LeftButton)
                {
                    OnMouseButton(Mouse);
                }
            }

            TCODKey key = TCODConsole.checkForKeypress();
            if (key.KeyCode != TCODKeyCode.NoKey)
            {

                ConsoleKey consoleKey = GetConsoleKey(key);
                OnKeyPress(consoleKey);
            }
        }

        protected void SetMouse(Mouse newMouse, TCODMouseData mouse)
        {
            newMouse.X = mouse.CellX;
            newMouse.Y = mouse.CellY;
            newMouse.LeftButton = mouse.LeftButton;
        }

        public override bool isClosed()
        {
            return TCODConsole.isWindowClosed();
        }

        protected ConsoleKey GetConsoleKey(TCODKey key)
        {
            ConsoleKey consoleKey = default(ConsoleKey);
            bool found = true;
            switch (key.KeyCode)
            {
                case TCODKeyCode.Space:
                    consoleKey = ConsoleKey.Spacebar; break;
                case TCODKeyCode.Right:
                    consoleKey = ConsoleKey.RightArrow; break;
                case TCODKeyCode.Left:
                    consoleKey = ConsoleKey.LeftArrow; break;
                case TCODKeyCode.Up:
                    consoleKey = ConsoleKey.UpArrow; break;
                case TCODKeyCode.Down:
                    consoleKey = ConsoleKey.DownArrow; break;
                default: found = false; break;
            }

            if (found)
            {
                return consoleKey;
            }
            else
            {
                string keyCodeString;
                if (key.KeyCode == TCODKeyCode.Char)
                {
                    keyCodeString = string.Format("{0}", key.Character);
                    Enum.TryParse(keyCodeString, true, out consoleKey);
                    return consoleKey;
                }
                else
                {
                    keyCodeString = string.Format("{0}", key.KeyCode);
                    Enum.TryParse(keyCodeString, true, out consoleKey);
                    return consoleKey;
                }

            }
        }

       protected static Dictionary<int, TCODColor> TCODColors = new Dictionary<int,TCODColor>();

       public static TCODColor getTCODColor(ConsoleRGB consoleRGB)
        {
            TCODColor color = null;

            if (consoleRGB.GetColorEnum() != null)
            {
                ColorEnum consoleColor = (ColorEnum)consoleRGB.GetColorEnum();


                switch (consoleColor)
                {
                    case ColorEnum.Black:
                        color = TCODColor.black;
                        break;
                    case ColorEnum.White:
                        color = TCODColor.white;
                        break;
                    case ColorEnum.Gray:
                        color = TCODColor.grey;
                        break;
                    case ColorEnum.Red:
                        color = TCODColor.red;
                        break;
                    case ColorEnum.Blue:
                        color = TCODColor.blue;
                        break;
                    case ColorEnum.Yellow:
                        color = TCODColor.yellow;
                        break;
                    case ColorEnum.DarkGray:
                        color = TCODColor.darkGrey;
                        break;
                    case ColorEnum.DarkRed:
                        color = TCODColor.darkRed;
                        break;
                    case ColorEnum.LightGray:
                        color = TCODColor.lightGrey;
                        break;
                    case ColorEnum.LightRed:
                        color = TCODColor.lightRed;
                        break;
                    default:
                        color = TCODColor.black;
                        break;
                }
            }
            else
            {
                int key = consoleRGB.R * 0x10000 + consoleRGB.G * 0x100 + consoleRGB.B;
                //TCODColor color;

                if (!TCODColors.TryGetValue(key, out color))
                {

                    color = new TCODColor();
                    color.Red = consoleRGB.R;
                    color.Green = consoleRGB.G;
                    color.Blue = consoleRGB.B;

                    TCODColors.Add(key, color);
                }
            }

            return color;
        }


    }
}
