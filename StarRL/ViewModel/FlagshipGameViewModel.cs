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
        public bool GalaxyViewEnabled{ get; set; }
        public FlagshipGame FlagshipGame { get; set; }

        public FlagshipGameScreen FlagshipGameScreen { get; set; }

        //public MainMenuViewModel MainScreenViewModel { get; set; }
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }
        public SystemScreenViewModel SystemScreenViewModel { get; set; }

        public FlagshipGameViewModel(FlagshipGameScreen flagshipGameScreen)
        {
            FlagshipGameScreen = flagshipGameScreen;
            Initialize();
        }

        public void Initialize()
        {
            //MainScreenViewModel = new MainMenuViewModel()
            //{
            //    MenuScreen = FlagshipGameScreen.MainScreen,
            //    FlagshipGameViewModel = this,
            //};
            //MainScreenViewModel.Initialize();

            GalaxyScreenViewModel = new GalaxyScreenViewModel(this, FlagshipGameScreen.GalaxyScreen);
            SystemScreenViewModel = new SystemScreenViewModel(this, FlagshipGameScreen.SystemScreen);
            //{
            //    GalaxyScreen = FlagshipGameScreen.GalaxyScreen,
            //    FlagshipGameViewModel = this,
            //};
            //GalaxyScreenViewModel.Initialize();

            FlagshipGameScreen.KeyPressEvent += new KeyPressEventHandler(KeyPressedEvent);

            DisplayMainMenu();
        }

        void KeyPressedEvent(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Tab:
                    ToggleView();
                    break;
            }
        }


        public void Update(int duration)
        {            
            if (FlagshipGame.Galaxy != null)
            {
                FlagshipGame.Update(duration);
                //GalaxyScreenViewModel.SetTime(TimeSpan.FromMilliseconds(FlagshipGame.Galaxy.Time));
            }
        }                

        public void Quit()
        {
            FlagshipGame.Complete = true;
            //FlagshipGameViewModel.Complete = true;
        }

        public void ToggleView()
        {
            GalaxyViewEnabled = !GalaxyViewEnabled;
            FlagshipGameScreen.GalaxyScreen.SetEnabled(GalaxyViewEnabled);
            FlagshipGameScreen.SystemScreen.SetEnabled(!GalaxyViewEnabled);
        }

        public void DisplayGame()
        {
            //FlagshipGameScreen.GalaxyScreen.SetEnabled(true);
            //FlagshipGameScreen.SystemScreen.SetEnabled(true);
            //FlagshipGameScreen.MainScreen.SetEnabled(false);

           // GalaxyScreenViewModel.SetFlagshipGame(FlagshipGame);           
        }

        public void DisplayMainMenu()
        {
            //FlagshipGameScreen.GalaxyScreen.SetEnabled(false);
            //FlagshipGameScreen.SystemScreen.SetEnabled(false);
            //MainScreen.MenuScreen.SetEnabled(true);
        }
    }
}
