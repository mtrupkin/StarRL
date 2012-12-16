using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyMasterComposite : Composite
    {
        public EntityDisplayControl GalaxyControl { get; set; }


        public GalaxyMasterComposite(Composite parent):base(parent, 80, 60)
        {

            GalaxyControl = new EntityDisplayControl(parent, 80-2, 60-2);

            var boxControl = new BoxControl(this, "Galaxy", 80, 60);

            AddControl(0, 0, boxControl);
            AddControl(1, 1, GalaxyControl);
        }
        

        void Fire() { }

    }
}
