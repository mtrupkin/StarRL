using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using StarRL.Widget;
using Flagship;

namespace StarRL
{
    public class GalaxyDetailComposite : VerticalComposite
	{
		public ShipDetailComposite FlagshipDetailControl { get; set; }

		public EntityDetailComposite TargetDetailControl { get; set; }

		public EntityBaseView HighlightedDetailControl { get; set; }

		public TimeWidget TimeWidget { get; set; }

        public GalaxyDetailComposite(Composite parent, int width, int height)
            : base(parent, width, height)
		{
            var detailComposite = new VerticalComposite(this, 1, 1);

            FlagshipDetailControl = new ShipDetailComposite(detailComposite, "Flagship");

            TargetDetailControl = new EntityDetailComposite(detailComposite, "Target");

            HighlightedDetailControl = new EntityBaseView(this);

            detailComposite.AddControl(FlagshipDetailControl);
            detailComposite.AddControl(TargetDetailControl);
            detailComposite.AddControl(HighlightedDetailControl);
            // TODO move to bottom of control

            TimeWidget = new TimeWidget(this);
            detailComposite.AddControl(TimeWidget);


            AddControl(new BoxWidget(detailComposite));
		}

	}
}
