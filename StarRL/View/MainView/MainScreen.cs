
using ConsoleLib;
namespace StarRL
{
    public class MainScreen : StackedComposite
    {
        public MenuScreen MenuScreen { get; set; }
        public FlagshipGameScreen GameScreen { get; set; }

        public MainScreen(Composite parent)
            : base(parent)
        {

            MenuScreen = new MenuScreen(parent) { GrabHorizontal = true, GrabVertical = true };

            GameScreen = new FlagshipGameScreen(parent) { GrabHorizontal = true, GrabVertical = false };
           
            AddControl(new LayoutData(MenuScreen) { VerticalJustify = VerticalJustify.Center });

            AddControl(GameScreen);
        }
    } 
}
