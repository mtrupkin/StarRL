using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class MainMenuScreen : CompositeBase
    {

        public ListWidget<Option> NewListWidget { get; set; }
        public ListWidget<Option> ContinueListWidget { get; set; }

        public MainMenuScreen(Composite parent)
            : base(parent, parent.Width, parent.Height)
        {
            SetLayoutManager(new StackedLayoutManager());

            NewListWidget = new ListWidget<Option>(this);
            ContinueListWidget = new ListWidget<Option>(this);

            AddControl(NewListWidget);
            AddControl(ContinueListWidget);            
        }
       

    }
}
