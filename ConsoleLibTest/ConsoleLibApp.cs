using System;
using Libtcod;
using ConsoleLib;

namespace ConsoleLibTest
{
    class ConsoleLibApp
    {
        Shell Shell { get; set; }

        bool Completed { get; set; }

        static void Main(string[] args)
        {
            ConsoleLibApp program = new ConsoleLibApp();
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
            var mainScreen = new MainScreen(Shell) { GrabHorizontal = true, GrabVertical = true };

            Shell.AddControl(new LayoutData(mainScreen) { });
            Shell.Resize();
        }

        // clean-up
        private void Dispose()
        {
            Shell.Dispose();
        }
    }
}
