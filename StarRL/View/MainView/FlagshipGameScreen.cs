using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;

namespace StarRL
{
    public class FlagshipGameScreen : Composite
    {
        public MainMenuScreen MainScreen { get; set; }
        public GalaxyScreen GalaxyScreen { get; set; }
         
        public FlagshipGameScreen(Composite parent):base (parent, 120,60) {
            Width = 140;
            Height = 60;

            MainScreen = new MainMenuScreen(parent)
            {
                Width = this.Width,
                Height = this.Height,
            };

            GalaxyScreen = new GalaxyScreen(parent)
            {
                Width = this.Width,
                Height = this.Height,
            };

            AddControl(0, 0, MainScreen);
            AddControl(0, 0, GalaxyScreen);
        }
    } 
}
