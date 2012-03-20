using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class MainMenuScreen : ConsoleScreen
    {

        public ListControl<Option> ListControl { get; set; }

        public MainMenuScreen()
        {
            ListControl = new ListControl<Option>()
            {
                Width = 30,
                Height = 10,
            };

            AddControl(10, 10, ListControl);
        }
       

    }
}
