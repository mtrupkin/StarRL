using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;

namespace StarRL
{
    public class FlagshipGameScreen : StackedComposite
    {
        public GalaxyScreen GalaxyScreen { get; set; }
        public SystemScreen SystemScreen { get; set; }
         
        public FlagshipGameScreen(Composite parent):base (parent) {

            GalaxyScreen = new GalaxyScreen(parent) { GrabHorizontal = true, GrabVertical = false };

            SystemScreen = new SystemScreen(parent) { GrabHorizontal = true, GrabVertical = false };
            SystemScreen.SetEnabled(false);

            AddControl(GalaxyScreen);
            AddControl(SystemScreen);
        }

    } 
}
