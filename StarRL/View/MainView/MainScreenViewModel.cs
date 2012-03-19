using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;
using ConsoleLib;
using ConsoleLib.Widget;

namespace StarRL
{
    public class MainScreenViewModel
    {
        public MainScreen MainScreen { get; set; }
        public FlagshipGameViewModel FlagshipGameViewModel  { get; set; }

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
            var flagshipGame = new FlagshipGame();

            GalaxyFactory galaxyFactory = new GalaxyFactory(80, 60);
            flagshipGame.Galaxy = galaxyFactory.CreateGalaxy();

            return flagshipGame;
        }

        public FlagshipGame LoadGameFile(String filename)
        {
            return null;
        }

        public void SaveGameFile(FlagshipGame galaxy)
        {
        }      

        public void NewGame()
        {
            FlagshipGameViewModel.BeginGame(CreateNewGame());
        }

        public void LoadGame()
        {
            FlagshipGameViewModel.BeginGame(CreateNewGame());
        }

        public void Quit()
        {
            FlagshipGameViewModel.Quit();
            //FlagshipGameViewModel.Complete = true;
        }

    }
}
