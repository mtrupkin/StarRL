using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarRL
{
    public class FlagshipGameScreen : ConsoleScreen
    {
        public MainMenuScreen MainScreen { get; set; }
        public GalaxyScreen GalaxyScreen { get; set; }
         
        public FlagshipGameScreen() {
            Width = 140;
            Height = 60;

            MainScreen = new MainMenuScreen()
            {
                Width = this.Width,
                Height = this.Height,
            };

            GalaxyScreen = new GalaxyScreen()
            {
                Width = this.Width,
                Height = this.Height,
            };

            AddControl(0, 0, MainScreen);
            AddControl(0, 0, GalaxyScreen);
        }
    } 
}
