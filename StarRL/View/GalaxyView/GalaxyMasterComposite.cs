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
        Galaxy Galaxy { get; set; }
        public EntityDisplayControl GalaxyControl { get; set; }


        public GalaxyMasterComposite(Galaxy newGalaxy)
        {
            Galaxy = newGalaxy;

            GalaxyControl = new EntityDisplayControl(Galaxy.StarSystems)
            {
                Width = 80-2,
                Height = 60-2,
            };            

            var boxControl = new BoxControl()
            {
                Title = "Galaxy",
                Width = 80,
                Height = 60,
            };

            AddControl(0, 0, boxControl);
            AddControl(1, 1, GalaxyControl);
        }
        

        void Fire() { }

    }
}
