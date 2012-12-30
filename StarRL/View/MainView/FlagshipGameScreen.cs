using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;

namespace StarRL
{
    public class FlagshipGameScreen : StackedComposite
    {
        public MainMenuScreen MainScreen { get; set; }
        public GalaxyScreen GalaxyScreen { get; set; }
         
        public FlagshipGameScreen(Composite parent):base (parent) {
            
            MainScreen = new MainMenuScreen(parent);

            GalaxyScreen = new GalaxyScreen(parent);

            AddControl(MainScreen);
            AddControl(GalaxyScreen);
        }
    } 
}
