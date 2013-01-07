using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class MainMenuScreen : VerticalComposite
    {

        public ListWidget<Option> NewListWidget { get; set; }
        public ListWidget<Option> ContinueListWidget { get; set; }

        public MainMenuScreen(Composite parent)
            : base(parent)
        {


            AddControl(new SpacerWidget(this, 1, 5), HorizontalJustify.Center);
            var titleWidget = new TextWidget(this, "Star Rogue");
            AddControl(new BoxWidget(titleWidget, 1), HorizontalJustify.Center);
            //AddControl(titleWidget, HorizontalJustify.Center);

            var stackedComposite = new StackedComposite(this);
            NewListWidget = new ListWidget<Option>(stackedComposite);
            ContinueListWidget = new ListWidget<Option>(stackedComposite);


            //stackedComposite.AddControl(new LayoutData(NewListWidget) { HorizontalJustify = HorizontalJustify.Center, VerticalJustify = VerticalJustify.Center });
            //stackedComposite.AddControl(new LayoutData(ContinueListWidget) { HorizontalJustify = HorizontalJustify.Center, VerticalJustify = VerticalJustify.Center });
            stackedComposite.AddControl(NewListWidget);
            stackedComposite.AddControl(ContinueListWidget);

            AddControl(new SpacerWidget(this, 1, 5), HorizontalJustify.Center);
            //AddControl(new BoxWidget(stackedComposite, 1), HorizontalJustify.Center);
            AddControl(stackedComposite, HorizontalJustify.Center);
            //AddControl(ContinueListWidget);            
        }
       

    }
}
