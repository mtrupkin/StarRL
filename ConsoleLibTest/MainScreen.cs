using ConsoleLib;
using ConsoleLib.Widget;

namespace ConsoleLibTest
{
    public class MainScreen : HorizontalComposite
    {
        public MainScreen(Composite parent)
            : base(parent)
        {
            var widget1 = new FrameWidget(this,5,1)
            {
                GrabVertical = true,
            };
            var data1 = new HorizontalLayoutData(widget1)
            ;
            var widget2 = new FrameWidget(this,5,1)
            {
                GrabVertical = true,
                GrabHorizontal = true,
            };
            var data2 = new HorizontalLayoutData(widget2)
            {
                
            };
 
            AddControl(data1);
            AddControl(data2);
        }
    }
}
