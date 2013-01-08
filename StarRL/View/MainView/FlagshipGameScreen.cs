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

            MainScreen = new MainMenuScreen(parent) { GrabHorizontal = true, GrabVertical = true };

            GalaxyScreen = new GalaxyScreen(parent) { GrabHorizontal = true, GrabVertical = false };

            AddControl(new LayoutData(MainScreen) {  VerticalJustify = VerticalJustify.Center});

            AddControl(new LayoutData(GalaxyScreen) { });

           // AddControl(GalaxyScreen);
        }
    } 
}
