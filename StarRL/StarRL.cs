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

            // main loop
            do
            {
                Shell.Render();

                if (Shell.isClosed())
                {
                    Exit();
                }

            } while (!FlagshipGame.Complete);
        }

        // first time initialization
        private void Initialize()
        {
            Completed = false;

            // initialize game model
            FlagshipGame = new FlagshipGame();

            // intialize console
            Shell = new Libtcod.LibtcodShell()
            {
                Title = "StarRL",
                Width = 120,
                Height = 60,
            };
            Shell.Initialize();

            // intialize view
            var FlagshipGameScreen = new FlagshipGameScreen();

            // initialize view model
            FlagshipGameViewModel = new FlagshipGameViewModel()
            {
                FlagshipGameScreen = FlagshipGameScreen,
                FlagshipGame = FlagshipGame,
            };
            FlagshipGameViewModel.Initialize();

            Shell.SetComposite(FlagshipGameViewModel.FlagshipGameScreen);

            // intialize game update tick
            updateTimer = new Timer(100);
            updateTimer.Elapsed += new ElapsedEventHandler(updateTimer_Elapsed);
            updateTimer.Start();

            lastUpdateTime = DateTime.Now;
            lastDrawTime = DateTime.Now;
        }

        void updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {            
            Update();
            //Draw();
        }
        
        //
        private void Draw() {
            TimeSpan lastDrawTimeSpan = DateTime.Now.Subtract(lastDrawTime);

            if (lastDrawTimeSpan > drawTimeSpan)
            {
                Shell.Render();

                lastDrawTime = DateTime.Now;
            }            
        }

        //
        private void Update()
        {
            TimeSpan lastUpdateTimeSpan = DateTime.Now.Subtract(lastUpdateTime);

            if (lastUpdateTimeSpan > updateTimeSpan)
            {
                FlagshipGameViewModel.Update(lastUpdateTimeSpan.Milliseconds);
                //FlagshipGame.Update(lastUpdateTimeSpan.Milliseconds);                

                lastUpdateTime = DateTime.Now;
            }
        }

        //
        private void Exit()
        {
            updateTimer.Stop();

            Shell.Dispose();

            FlagshipGame.Complete = true;
        }
    }
}
