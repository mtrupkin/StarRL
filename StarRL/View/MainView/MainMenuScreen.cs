using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class MainMenuScreen : Composite
    {

        public ListControl<Option> ListControl { get; set; }

        public MainMenuScreen(Composite parent):base(parent, 30, 10)
        {
            ListControl = new ListControl<Option>(this)
            {
                Width = 30,
                Height = 10,
            };

            AddControl(ListControl);
            //AddControl(10, 10, ListControl);
        }
       

    }
}
