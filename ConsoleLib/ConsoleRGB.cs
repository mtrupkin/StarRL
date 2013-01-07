using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public enum ColorEnum
    {
        // Summary:
        //     The color black.
        Black = 0,
        //
        // Summary:
        //     The color dark blue.
        DarkBlue = 1,
        //
        // Summary:
        //     The color dark green.
        DarkGreen = 2,
        //
        // Summary:
        //     The color dark cyan (dark blue-green).
        DarkCyan = 3,
        //
        // Summary:
        //     The color dark red.
        DarkRed = 4,
        //
        // Summary:
        //     The color dark magenta (dark purplish-red).
        DarkMagenta = 5,
        //
        // Summary:
        //     The color dark yellow (ochre).
        DarkYellow = 6,
        //
        // Summary:
        //     The color gray.
        Gray = 7,
        //
        // Summary:
        //     The color dark gray.
        DarkGray = 8,
        //
        // Summary:
        //     The color blue.
        Blue = 9,
        //
        // Summary:
        //     The color green.
        Green = 10,
        //
        // Summary:
        //     The color cyan (blue-green).
        Cyan = 11,
        //
        // Summary:
        //     The color red.
        Red = 12,
        //
        // Summary:
        //     The color magenta (purplish-red).
        Magenta = 13,
        //
        // Summary:
        //     The color yellow.
        Yellow = 14,
        //
        // Summary:
        //     The color white.
        White = 15,

        LightBlue,
        LightGreen,
        LightCyan,
        LightRed,
        LightMagenta,
        LightYellow,
        LightGray

    }
    public class ConsoleRGB
    {
        public static ConsoleRGB White = new ConsoleRGB()
        {
            R = 255,
            G = 255,
            B = 255,
            ColorEnum = ColorEnum.White,
        };
        public static ConsoleRGB Black = new ConsoleRGB()
        {
            R = 0,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.Black,
        };
        public static ConsoleRGB Gray = new ConsoleRGB()
        {
            R = 127,
            G = 127,
            B = 127,
            ColorEnum = ColorEnum.Gray,
        };
        public static ConsoleRGB DarkGray = new ConsoleRGB()
        {
            R = 95,
            G = 95,
            B = 95,
            ColorEnum = ColorEnum.DarkGray,
        };
        public static ConsoleRGB LightGray = new ConsoleRGB()
        {
            R = 250,
            G = 250,
            B = 250,
            //R = 95,
            //G = 95,
            //B = 95,
            ColorEnum = ColorEnum.LightGray,
        };
        public static ConsoleRGB Red = new ConsoleRGB()
        {
            R = 255,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.Red,
        };
        public static ConsoleRGB DarkRed = new ConsoleRGB()
        {
            R = 191,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.DarkRed,
        };

        public static ConsoleRGB Blue = new ConsoleRGB()
        {
            R = 0,
            G = 0,
            B = 255,
            ColorEnum = ColorEnum.Blue,
        };

        public static ConsoleRGB Yellow = new ConsoleRGB()
        {
            R = 255,
            G = 255,
            B = 0,
            ColorEnum = ColorEnum.Yellow,
        };

        public static ConsoleRGB Transparent = new ConsoleRGB()
        {
            R = 255,
            G = 0,
            B = 0,
            ColorEnum = ColorEnum.Red,
        };

        public static ConsoleRGB Space = new ConsoleRGB()
        {
            R = 0,
            G = 15,
            B = 19,
        };


        // solorized
        public static ConsoleRGB Base03 = new ConsoleRGB()
        {
            R = 0,
            G = 43,
            B = 54,
        };

        public static ConsoleRGB Base02 = new ConsoleRGB()
        {
            R = 7,
            G = 54,
            B = 66,
        };

        public static ConsoleRGB Base01 = new ConsoleRGB()
        {
            R = 88,
            G = 110,
            B = 117,
        };

        public static ConsoleRGB Base00 = new ConsoleRGB()
        {
            R = 101,
            G = 123,
            B = 131,
        };

        public static ConsoleRGB Base0 = new ConsoleRGB()
        {
            R = 131,
            G = 148,
            B = 150,
        };

        public static ConsoleRGB Base1 = new ConsoleRGB()
        {
            R = 147,
            G = 161,
            B = 161,
        };

        public static ConsoleRGB Base2 = new ConsoleRGB()
        {
            R = 238,
            G = 232,
            B = 213,
        };


        public static ConsoleRGB Base3 = new ConsoleRGB()
        {
            R = 253,
            G = 246,
            B = 227,
        };


        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        ColorEnum? colorEnum = null;

        public ColorEnum? GetColorEnum() { return colorEnum; }

        public ColorEnum ColorEnum { set { colorEnum = (ColorEnum)value; } }

    }
}
