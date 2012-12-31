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
            MainScreen.NewListWidget.AddItem(new Option() { Name = " Create Game ", OptionHandler = NewGame });
            MainScreen.NewListWidget.AddItem(new Option() { Name = "Load Game", OptionHandler = LoadGame });
            MainScreen.NewListWidget.AddItem(new Option() { Name = "Quit", OptionHandler = Quit });

            MainScreen.ContinueListWidget.AddItem(new Option() { Name = "Create Game", OptionHandler = NewGame });
            MainScreen.ContinueListWidget.AddItem(new Option() { Name = " Continue Game ", OptionHandler = ContinueGame });
            MainScreen.ContinueListWidget.AddItem(new Option() { Name = "Load Game", OptionHandler = LoadGame });
            MainScreen.ContinueListWidget.AddItem(new Option() { Name = "Quit", OptionHandler = Quit });

            MainScreen.NewListWidget.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);
            MainScreen.ContinueListWidget.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);

            MainScreen.NewListWidget.SetEnabled(true);
            MainScreen.ContinueListWidget.SetEnabled(false);

            MainScreen.KeyPressEvent += new KeyPressEventHandler(KeyPressedEvent);
        }

        void KeyPressedEvent(ConsoleKey consoleKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.Escape:
                    Quit();
                    break;
            }
        }

        void ListControl_SelectedEvent(Option item)
        {
            item.OptionHandler();
        }       

        // initialization for each new game
        public void CreateNewGame()
        {
            MainScreen.NewListWidget.SetEnabled(false);
            MainScreen.ContinueListWidget.SetEnabled(true);

            GalaxyFactory galaxyFactory = new GalaxyFactory(128, 72);
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
