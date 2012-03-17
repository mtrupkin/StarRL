using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;


namespace StarRL.View
{
    public class ViewModel<T> where T : Composite
    {
        public Composite View { get; set; }


    }
}
