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


        public MainScreen()
        {
            ListControl = new ListControl<Option>()
            {
                Width = 30,
                Height = 10,
            };

            ListControl.AddItem(new Option() { Name = "Create New Game", OptionHandler = NewGame });
            ListControl.AddItem(new Option() { Name = "Save Current Game", OptionHandler = SaveGame });
            ListControl.AddItem(new Option() { Name = "Load Existing Game", OptionHandler = LoadGame});
            ListControl.AddItem(new Option() { Name = "Quit", OptionHandler = Quit});

            ListControl.ItemSelectedEvent += new ItemSelectedEventHandler<Option>(ListControl_SelectedEvent);

            AddControl(10, 10, ListControl);

        }

        void ListControl_SelectedEvent(Option item)
        {
            item.OptionHandler();
        }

        private void Quit()
        {
            Complete = true;
        }

        // initialization for each new game
        private void NewGame()
        {
            GalaxyFactory galaxyFactory = new GalaxyFactory(80, 60);
            Galaxy galaxy = galaxyFactory.CreateGalaxy();

            BeginGame(galaxy);
        }

        private void ContinueGame()
        {
            BeginGame(null);
        }

        private void LoadGame()
        {
            BeginGame(null);
        }

        private void SaveGame()
        {
            BeginGame(null);
        }

        private void BeginGame(Galaxy galaxy)
        {
            ChangeScreen(new GalaxyScreen(galaxy));
        }      

    }
}
