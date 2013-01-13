using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyMasterComposite : VerticalComposite
    {
        public EntityDisplayControl GalaxyControl { get; set; }

        public GalaxyMasterComposite(Composite parent)
            : base(parent)
        {

            GalaxyControl = new EntityDisplayControl(this);

            AddControl(GalaxyControl);
        }        

        void Fire() { }

    }
}
