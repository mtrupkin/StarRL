using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;
using ConsoleLib;
using ConsoleLib.Widget;

namespace StarRL
{
    public class FlagshipGameViewModel
    {
        //public bool Completed { get; set; }
        public FlagshipGame FlagshipGame { get; set; }

        public FlagshipGameScreen FlagshipGameScreen { get; set; }

        public MainScreenViewModel MainScreenViewModel { get; set; }
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }

        public void Initialize()
        {
            MainScreenViewModel = new MainScreenViewModel()
            {
                MainScreen = FlagshipGameScreen.MainScreen,
                FlagshipGameViewModel = this,
            };
            MainScreenViewModel.Initialize();

            GalaxyScreenViewModel = new GalaxyScreenViewModel()
            {
                GalaxyScreen = FlagshipGameScreen.GalaxyScreen,
                FlagshipGameViewModel = this,
            };
            GalaxyScreenViewModel.Initialize();

            DisplayMainMenu();
        }

        public void Update(int duration)
        {            
            if (FlagshipGame.Galaxy != null)
            {
                FlagshipGame.Update(duration);
                GalaxyScreenViewModel.SetTime(TimeSpan.FromMilliseconds(FlagshipGame.Galaxy.Time));
            }
        }                

        public void Quit()
        {
            FlagshipGame.Complete = true;
            //FlagshipGameViewModel.Complete = true;
        }



        public void DisplayGame()
        {
            FlagshipGameScreen.GalaxyScreen.Enabled = true;
            FlagshipGameScreen.MainScreen.Enabled = false;

            GalaxyScreenViewModel.SetFlagshipGame(FlagshipGame);           
        }

        public void DisplayMainMenu()
        {
            FlagshipGameScreen.GalaxyScreen.Enabled = false;
            FlagshipGameScreen.MainScreen.Enabled = true;
        }
    }
}
