using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
using ConsoleLib;

namespace Libtcod
{
	public class LibtcodConsole : Screen
	{
		public TCODConsole Con { get; set; }

		int CursorX { get; set; }

		int CursorY { get; set; }

		public ConsoleRGB ForegroundColor { get; set; }

		public ConsoleRGB BackgroundColor { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }
    
		public LibtcodConsole (int width, int height)
		{
			Width = width;
			Height = height;

			Con = new TCODConsole (width, height);
			Initialize ();
		}

		public LibtcodConsole (int width, int height, TCODConsole root)
		{
			Width = width;
			Height = height;

			Con = root;
			Initialize ();
		}

		void Initialize ()
		{
			Con.setBackgroundFlag (TCODBackgroundFlag.Overlay);
			BackgroundColor = ConsoleRGB.Black;
			ForegroundColor = ConsoleRGB.White;
			Con.setKeyColor (TCODColor.red);
		}

		public void Clear ()
		{
			TCODColor bg = getTCODColor (BackgroundColor);
            
			Con.setBackgroundColor (bg);
			Con.clear ();
		}

		public void Write (char c)
		{
			TCODColor bg = getTCODColor (BackgroundColor);
			TCODColor fg = getTCODColor (ForegroundColor);
			Con.putCharEx (CursorX, CursorY, c, fg, bg);
		}

		public void WriteFrame (int width, int height)
		{
			TCODColor bg = getTCODColor (BackgroundColor);
			TCODColor fg = getTCODColor (ForegroundColor);
			
			Con.setBackgroundColor (bg);
			Con.setForegroundColor (fg);                        
  
			Con.printFrame (CursorX, CursorY, width, height);
            
		}

		public void WriteFrame (int width, int height, String title)
		{
			TCODColor bg = getTCODColor (BackgroundColor);
			TCODColor fg = getTCODColor (ForegroundColor);
			Con.setBackgroundColor (bg);
			Con.setForegroundColor (fg);                        
  
			Con.printFrame (CursorX, CursorY, width, height, false, TCODBackgroundFlag.Set, title);

		}

		public void Write (string s)
		{
			TCODColor bg = getTCODColor (BackgroundColor);
			TCODColor fg = getTCODColor (ForegroundColor);
			Con.setBackgroundColor (bg);
			Con.setForegroundColor (fg);                        
			Con.printEx (CursorX, CursorY, TCODBackgroundFlag.Set, TCODAlignment.LeftAlignment, s);
            
		}

        public void Display(int x, int y, Screen console)
		{
			LibtcodConsole tcodConsole = console as LibtcodConsole;
			TCODConsole.blit (tcodConsole.Con, 0, 0, console.Width, console.Height, Con, x, y);
		}

		public void Dispose ()
		{
			Con.Dispose ();
		}

		public void SetPosition (int x, int y)
		{
			CursorX = x;
			CursorY = y;
		}

		TCODColor getTCODColor (ConsoleRGB consoleRGB)
		{
			TCODColor color = null;

			if (consoleRGB.GetColorEnum () != null) {
				ColorEnum consoleColor = (ColorEnum)consoleRGB.GetColorEnum ();


				switch (consoleColor) {
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
			} else {
				color = new TCODColor ();
				color.Red = consoleRGB.R;
				color.Green = consoleRGB.G;
				color.Blue = consoleRGB.B;
			}            
            
			return color;
		}

	}
}
