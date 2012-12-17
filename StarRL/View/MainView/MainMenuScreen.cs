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

        public ListWidget<Option> ListWidget { get; set; }

        public MainMenuScreen(Composite parent)
            : base(parent, parent.Width, parent.Height)
        {
            ListWidget = new ListWidget<Option>(this);

            AddControl(ListWidget);            
        }
       

    }
}
