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
        public FlagshipGame FlagshipGame { get; set; }

        public MainScreen MainScreen { get; set; }
        public GalaxyScreen GalaxyScreen { get; set; }

        public MainScreenViewModel MainScreenViewModel { get; set; }
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }

        public Shell Shell { get; set; }

        public void Initialize()
        {
            // intialize ui
            MainScreen = new MainScreen();
            GalaxyScreen = new GalaxyScreen();

            MainScreenViewModel = new MainScreenViewModel()
            {
                MainScreen = MainScreen,
                FlagshipGameViewModel = this,
            };

            MainScreenViewModel.Initialize();

            GalaxyScreenViewModel = new GalaxyScreenViewModel()
            {
                GalaxyScreen = GalaxyScreen,
                FlagshipGame = FlagshipGame
            };

            GalaxyScreenViewModel.Initialize();


            DisplayMainMenu();

        }

        public void BeginGame(FlagshipGame flagshipGame)
        {
            //galaxyScreenViewModel
            DisplayGame();
        }

        public void Quit()
        {
            //FlagshipGameViewModel.Complete = true;
        }

        public void DisplayGame()
        {
            Shell.SetComposite(GalaxyScreen);
        }

        public void DisplayMainMenu()
        {
            Shell.SetComposite(MainScreen);
        }
    }
}
