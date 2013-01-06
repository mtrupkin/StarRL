﻿using System;
using Libtcod;
using ConsoleLib;

namespace ConsoleLibTest
{
    class Program
    {
        Shell Shell { get; set; }

        bool Completed { get; set; }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            // first time initialization
            Initialize();

            bool complete = false;
            // main loop
            do
            {
                Shell.Render();

                if (Shell.isClosed() )
                {
                    complete = true;
                }

            } while (!complete);

            Dispose();
        }

        // first time initialization
        private void Initialize()
        {
            Completed = false;

            // intialize console
            Shell = new Libtcod.LibtcodShell("Console Lib Test", 160, 90);

            // intialize view
            var mainScreen = new MainScreen(Shell);

            Shell.AddControl(new LayoutData(mainScreen) { GrabHorizontal = true, GrabVertical = true });
            Shell.Resize();
        }

        // clean-up
        private void Dispose()
        {
            Shell.Dispose();
        }
    }
}
