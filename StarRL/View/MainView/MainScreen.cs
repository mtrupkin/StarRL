using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{
    public delegate void OptionHandler();

    public class Option
    {
        public string Name { get; set; }
        public OptionHandler OptionHandler { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MainScreen : ConsoleScreen
    {

        public ListControl<Option> ListControl { get; set; }

        public MainScreen()
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
