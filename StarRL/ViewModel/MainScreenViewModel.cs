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
        public MainMenuScreen MainScreen { get; set; }
        public FlagshipGameViewModel FlagshipGameViewModel  { get; set; }

        public List<Option> List1;
        public List<Option> List2;

        public void Initialize()
        {
            List1 = new List<Option>();
            List1.Add(new Option() { Name = "Create New Game", OptionHandler = NewGame });
            List1.Add(new Option() { Name = "Load Existing Game", OptionHandler = LoadGame });
            List1.Add(new Option() { Name = "Quit", OptionHandler = Quit });

            List2 = new List<Option>();
            List2.Add(new Option() { Name = "Create New Game", OptionHandler = NewGame });
            List2.Add(new Option() { Name = "Continue Game", OptionHandler = ContinueGame });
            List2.Add(new Option() { Name = "Load Existing Game", OptionHandler = LoadGame });
            List2.Add(new Option() { Name = "Quit", OptionHandler = Quit });

            MainScreen.ListWidget.Items = List1;

            MainScreen.ListWidget.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);
        }

        void ListControl_SelectedEvent(Option item)
        {
            item.OptionHandler();
        }       

        // initialization for each new game
        public void CreateNewGame()
        {
            MainScreen.ListWidget.Items = List2;
            GalaxyFactory galaxyFactory = new GalaxyFactory(80, 60);
            FlagshipGameViewModel.FlagshipGame.Galaxy = galaxyFactory.CreateGalaxy();
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
            CreateNewGame();
            FlagshipGameViewModel.DisplayGame(); 
        }

        public void ContinueGame()
        {
            FlagshipGameViewModel.DisplayGame();
        }

        public void LoadGame()
        {
            CreateNewGame();
            FlagshipGameViewModel.DisplayGame(); 
        }

        public void Quit()
        {
            FlagshipGameViewModel.Quit();
            //FlagshipGameViewModel.Complete = true;
        }

    }
}
