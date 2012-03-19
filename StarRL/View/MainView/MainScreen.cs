using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{
    public delegate void OptionHandler();

    public class Option
    {
        public string Name { get; set; }
        public OptionHandler OptionHandler { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MainScreen : ConsoleScreen
    {

        ListControl<Option> ListControl { get; set; }

        public FlagshipGameViewModel FlagshipGameViewModel { get; set; }

        public MainScreen()
        {
            ListControl = new ListControl<Option>()
            {
                Width = 30,
                Height = 10,
            };

            ListControl.AddItem(new Option() { Name = "Create New Game", OptionHandler = NewGame });
            ListControl.AddItem(new Option() { Name = "Load Existing Game", OptionHandler = LoadGame});
            ListControl.AddItem(new Option() { Name = "Quit", OptionHandler = Quit});

            ListControl.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);

            AddControl(10, 10, ListControl);

        }

        void ListControl_SelectedEvent(Option item)
        {
            item.OptionHandler();
        }

        void NewGame()
        {
            BeginGame(FlagshipGameViewModel.NewGame());
        }

        void LoadGame()
        {
            FlagshipGameViewModel.NewGame();
            BeginGame(FlagshipGameViewModel.NewGame());
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

            ChangeScreen(galaxyScreen);
        }      

        private void Quit()
        {
            Complete = true;
        }

    }
}
