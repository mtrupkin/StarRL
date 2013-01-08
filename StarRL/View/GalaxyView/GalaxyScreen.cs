using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyScreen : HorizontalComposite
    {
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }

        public GalaxyMasterComposite GalaxyMasterComposite { get; set; }
        public GalaxyDetailComposite GalaxyDetailComposite { get; set; }

        public GalaxyScreen(Composite parent)
            : base(parent)
        {
            GalaxyMasterComposite = new GalaxyMasterComposite(this);
            GalaxyDetailComposite = new GalaxyDetailComposite(this) { GrabHorizontal = true, };

            var boxWidget = new BoxWidget(GalaxyDetailComposite) { GrabHorizontal = true, GrabVertical = true };
            AddControl(GalaxyMasterComposite);
            AddControl(boxWidget);
        }
    }
}
