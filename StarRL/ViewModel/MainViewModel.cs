using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;

namespace StarRL
{
    public class MainViewModel
    {
        public FlagshipGame FlagshipGame { get; set; }

        public MainScreen MainScreen { get; set; }
        public MainMenuViewModel MainScreenViewModel { get; set; }
        public FlagshipGameViewModel FlagshipGameViewModel { get; set; }

        public MainViewModel(MainScreen mainScreen)
        {
            MainScreen = mainScreen;
            MainScreenViewModel = new MainMenuViewModel(this, MainScreen.MenuScreen);
            FlagshipGameViewModel = new FlagshipGameViewModel(MainScreen.GameScreen);
        }

        public void Update(int duration)
        {
            if (FlagshipGame.Galaxy != null)
            {
                FlagshipGame.Update(duration);
                //GalaxyScreenViewModel.SetTime(TimeSpan.FromMilliseconds(FlagshipGame.Galaxy.Time));
            }
        }

        public void DisplayMainMenu()
        {
            MainScreen.GameScreen.SetEnabled(false);
            MainScreen.MenuScreen.SetEnabled(true);
        }

        public void DisplayGame()
        {
            MainScreen.GameScreen.SetEnabled(true);
            MainScreen.MenuScreen.SetEnabled(false);
        }

        public void Quit()
        {
            FlagshipGame.Complete = true;
        }

        public void CreateNewGame()
        {
            GalaxyFactory galaxyFactory = new GalaxyFactory(128, 72);
            FlagshipGame.Galaxy = galaxyFactory.CreateGalaxy();
            FlagshipGameViewModel.GalaxyScreenViewModel.SetFlagshipGame(FlagshipGame);
            
            
        }
    }
}
