using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine;
using Libtcod;
using ConsoleLib;
using Flagship;
using System.Timers;

namespace StarRL
{
    //
    // Main class for running game
    //
    class StarRL
    {
        Shell Shell { get; set; }

        FlagshipGame FlagshipGame { get; set; }
        FlagshipGameViewModel FlagshipGameViewModel { get; set; }

        System.Timers.Timer updateTimer;
        DateTime lastUpdateTime;
        TimeSpan updateTimeSpan = new TimeSpan(0, 0, 0, 0, 10);

        DateTime lastDrawTime;        
        TimeSpan drawTimeSpan = new TimeSpan(0, 0, 0, 0, 25);

        bool Completed { get; set; }

        static void Main(string[] args)
        {
            StarRL starRL = new StarRL();
            starRL.Run();
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

                if (Shell.isClosed() || FlagshipGame.Complete)
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

            // initialize game model
            FlagshipGame = new FlagshipGame();

            // intialize console
            Shell = new Libtcod.LibtcodShell("StarRL", 160, 90);
            
            // intialize view
            var FlagshipGameScreen = new FlagshipGameScreen(Shell) { GrabHorizontal = true, GrabVertical = true };

            // initialize view model
            FlagshipGameViewModel = new FlagshipGameViewModel()
            {
                FlagshipGameScreen = FlagshipGameScreen,
                FlagshipGame = FlagshipGame,
            };
            FlagshipGameViewModel.Initialize();

            Shell.AddControl(new LayoutData(FlagshipGameScreen) );
            Shell.Resize();

            // intialize game update tick
            updateTimer = new Timer(100);
            updateTimer.Elapsed += new ElapsedEventHandler(updateTimer_Elapsed);
            updateTimer.Start();

            lastUpdateTime = DateTime.Now;
            lastDrawTime = DateTime.Now;
        }

        // clean-up
        private void Dispose()
        {
            updateTimer.Stop();

            Shell.Dispose();

            FlagshipGame.Complete = true;
        }

        void updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {            
            Update();
        }
        
        //
        private void Update()
        {
            TimeSpan lastUpdateTimeSpan = DateTime.Now.Subtract(lastUpdateTime);

            if (lastUpdateTimeSpan > updateTimeSpan)
            {
                FlagshipGameViewModel.Update(lastUpdateTimeSpan.Milliseconds);

                lastUpdateTime = DateTime.Now;
            }
        }
    }
}
