using ConsoleLib;
using ConsoleLib.Widget;

namespace ConsoleLibTest
{
    public class MainScreen : HorizontalComposite
    {
        public MainScreen(Composite parent)
            : base(parent)
        {
            var widget1 = new FrameWidget(this);
            var data1 = new HorizontalLayoutData(widget1)
            {
                GrabVertical = true,
            };
            var widget2 = new FrameWidget(this);
            var data2 = new HorizontalLayoutData(widget2)
            {
                GrabVertical = true,
                GrabHorizontal = true,
            };
 
            AddControl(data1);
            AddControl(data2);
        }
    }
}
