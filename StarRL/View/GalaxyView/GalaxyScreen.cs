using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyScreen : Composite
    {
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }

        public GalaxyMasterComposite GalaxyMasterComposite { get; set; }
        public GalaxyDetailComposite GalaxyDetailComposite { get; set; }

        public GalaxyScreen(Composite parent) : base (parent, 120, 60)
        {
            GalaxyMasterComposite = new GalaxyMasterComposite(this)
            {
                Width = 80,
                Height= 60,
            };

            GalaxyDetailComposite = new GalaxyDetailComposite(this)
            {
                Width = 40,
                Height = 60,
            };

            AddControl(0, 0, GalaxyMasterComposite);
            AddControl(80, 0, GalaxyDetailComposite);
        }
    }
}
