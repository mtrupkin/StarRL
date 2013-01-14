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

        public MainViewModel MainViewModel { get; set; }
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }
        public SystemScreenViewModel SystemScreenViewModel { get; set; }

        public FlagshipGameViewModel(FlagshipGame flagshipGame, MainViewModel mainViewModel, FlagshipGameScreen flagshipGameScreen)
        {
            FlagshipGameScreen = flagshipGameScreen;
            MainViewModel = mainViewModel;
            FlagshipGame = flagshipGame;
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
            GalaxyViewEnabled = true;

            DisplayMainMenu();
        }

        void KeyPressedEvent(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Tab:
                    ToggleView();
                    break;
                case ConsoleKey.Escape:
                    DisplayMainMenu();
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

            SystemScreenViewModel.SystemScreen.SystemMasterComposite.SystemControl.Resize(100, 60);
            //SystemScreenViewModel.SystemScreen.SystemMasterComposite.SystemControl.Entities;
            //FlagshipGame.Galaxy.Flagship;
        }


        public void DisplayMainMenu()
        {
            MainViewModel.DisplayMainMenu();
            //FlagshipGameScreen.GalaxyScreen.SetEnabled(false);
            //FlagshipGameScreen.SystemScreen.SetEnabled(false);
            //MainScreen.MenuScreen.SetEnabled(true);
        }

        public void SetFlagshipGame(FlagshipGame flagshipGame)
        {
            FlagshipGame = flagshipGame;
            var entities = new List<IDrawable<Entity>>();

            entities.AddRange(DrawableFactory.GetDrawableStarSystems(FlagshipGame.Galaxy.StarSystems));
            entities.Add(DrawableFactory.GetDrawableShip(FlagshipGame.Galaxy.Flagship));



           FlagshipGameScreen.GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Entities = entities;
           FlagshipGameScreen.GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Flagship = DrawableFactory.GetDrawableShip(FlagshipGame.Galaxy.Flagship);
           FlagshipGameScreen.GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Resize(FlagshipGame.Galaxy.Width, FlagshipGame.Galaxy.Height);
           FlagshipGameScreen.GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetShip(FlagshipGame.Galaxy.Flagship);
           FlagshipGameScreen.GalaxyScreen.Resize();

           //FlagshipGameScreen.SystemScreen.SystemMasterComposite.SystemControl.Entities = entities;
           FlagshipGameScreen.SystemScreen.SystemMasterComposite.SystemControl.Flagship = DrawableFactory.GetDrawableShip(FlagshipGame.Galaxy.Flagship);
           FlagshipGameScreen.SystemScreen.SystemMasterComposite.SystemControl.Resize(FlagshipGame.Galaxy.Width, FlagshipGame.Galaxy.Height);
           FlagshipGameScreen.SystemScreen.SystemDetailComposite.FlagshipDetailControl.SetShip(FlagshipGame.Galaxy.Flagship);
           FlagshipGameScreen.SystemScreen.Resize();

        }

    }
}
