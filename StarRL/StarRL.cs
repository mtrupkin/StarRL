using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine;
using Libtcod;
using ConsoleLib;

namespace StarRL
{
    //
    // Main class for running game
    //
    class StarRL
    {

        Shell Shell { get; set; }

        StateMachine<ConsoleScreen> ScreenStateMachine { get; set; }

        static void Main(string[] args)
        {
            StarRL starRL = new StarRL();
            starRL.Run();
        }

        private void Run()
        {
            // first time initialization
            Initialize();

            // main loop
            bool closed = false;

            do
            {
                //
                closed = Update();
            } while (!closed);
        }

        // first time initialization
        private void Initialize()
        {
            Shell = new Libtcod.LibtcodShell()
            {
                Title = "StarRL",
                Width = 120,
                Height = 60,
            };

            Shell.Initialize();
            ScreenStateMachine = new StateMachine<ConsoleScreen>();
            MainScreen mainScreen = new MainScreen()
            {
                Shell = Shell,
                StateMachine = ScreenStateMachine,
            };

            ScreenStateMachine.CurrentState = mainScreen;
            Shell.SetComposite(mainScreen);
        }

        //
        private bool Update()
        {

            ScreenStateMachine.Update(200);
            bool complete = ScreenStateMachine.CurrentState.Complete;

            if (Shell.isClosed())
            {
                Shell.Dispose();

                complete = true;
            }
            return complete;
        }

    }
}
