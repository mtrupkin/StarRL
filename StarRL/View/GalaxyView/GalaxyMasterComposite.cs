using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyMasterComposite : CompositeBase
    {
        public EntityDisplayControl GalaxyControl { get; set; }

        public GalaxyMasterComposite(Composite parent, int width, int height)
            : base(parent, width, height)
        {

            GalaxyControl = new EntityDisplayControl(parent, width - 2, height - 2);

            var boxControl = new BoxWidget(GalaxyControl, "Galaxy");

            //SetLayoutManager(new StackedLayoutManager());
            AddControl(boxControl);
            //GalaxyControl.X = 1;
            //GalaxyControl.Y = 1;
            //AddControl(GalaxyControl);
        }        

        void Fire() { }

    }
}
