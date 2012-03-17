using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{

    public class GalaxyScreen : ConsoleScreen
    {
        GalaxyScreenViewModel GalaxyScreenViewModel { get; set; }

        public GalaxyMasterComposite GalaxyMasterComposite { get; set; }
        public GalaxyDetailComposite GalaxyDetailComposite { get; set; }

        public GalaxyScreen(Galaxy galaxy)
        {
            GalaxyMasterComposite = new GalaxyMasterComposite(galaxy)
            {
                Width = 80,
                Height= 60,
            };

            GalaxyDetailComposite = new GalaxyDetailComposite()
            {
                Width = 40,
                Height = 60,
            };

            AddControl(0, 0, GalaxyMasterComposite);
            AddControl(80, 0, GalaxyDetailComposite);

            GalaxyScreenViewModel = new GalaxyScreenViewModel(this);
            GalaxyScreenViewModel.Galaxy = galaxy;
        }

        public override int Update(int duration)
        {
            GalaxyScreenViewModel.Update(duration);

            return base.Update(duration);
        }
        private void Quit()
        {
            Complete = true;
        }

    }
}
