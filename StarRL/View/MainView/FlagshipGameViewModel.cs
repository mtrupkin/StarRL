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
        public MainScreen MainScreen { get; set; }
        public FlagshipGame FlagshipGame { get; set; }
        public Shell Shell { get; set; }

        public void Initialize()
        {
            MainScreen.ListControl.AddItem(new Option() { Name = "Create New Game", OptionHandler = NewGame });
            MainScreen.ListControl.AddItem(new Option() { Name = "Load Existing Game", OptionHandler = LoadGame });
            MainScreen.ListControl.AddItem(new Option() { Name = "Quit", OptionHandler = Quit });

            MainScreen.ListControl.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);
        }

        void ListControl_SelectedEvent(Option item)
        {
            item.OptionHandler();
        }       

        // initialization for each new game
        public FlagshipGame CreateNewGame()
        {
            GalaxyFactory galaxyFactory = new GalaxyFactory(80, 60);
            FlagshipGame.Galaxy = galaxyFactory.CreateGalaxy();

            return FlagshipGame;
        }

        public FlagshipGame LoadGameFile(String filename)
        {
            return null;
        }

        public void SaveGameFile(FlagshipGame galaxy)
        {
        }

        private void BeginGame(FlagshipGame flagshipGame)
        {
            var galaxyScreen = new GalaxyScreen()
            {
            };

            var galaxyScreenViewModel = new GalaxyScreenViewModel()
            {
                GalaxyScreen = galaxyScreen,
                FlagshipGame = flagshipGame
            };
            galaxyScreenViewModel.Initialize();

            Shell.SetComposite(galaxyScreen);
        }

        public void NewGame()
        {
            BeginGame(CreateNewGame());
        }

        public void LoadGame()
        {
            BeginGame(CreateNewGame());
        }

        public void Quit()
        {
            //FlagshipGameViewModel.Complete = true;
        }

    }
}
