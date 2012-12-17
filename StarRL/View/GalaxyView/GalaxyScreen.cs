using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyScreen : CompositeBase
    {
        public GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }

        public GalaxyMasterComposite GalaxyMasterComposite { get; set; }
        public GalaxyDetailComposite GalaxyDetailComposite { get; set; }

        public GalaxyScreen(Control parent)
            : base(parent, parent.Width, parent.Height)
        {
            GalaxyMasterComposite = new GalaxyMasterComposite(this, 80, parent.Height);

            GalaxyDetailComposite = new GalaxyDetailComposite(this, 40, parent.Height);

            SetLayoutManager(new HorizontalLayout());

            AddControl(GalaxyMasterComposite);
            AddControl(GalaxyDetailComposite);
        }
    }
}
