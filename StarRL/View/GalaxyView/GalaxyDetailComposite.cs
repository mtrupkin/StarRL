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

        public GalaxyDetailComposite(Composite parent)
            : base(parent)
		{
            var detailComposite = new VerticalComposite(this);

            FlagshipDetailControl = new ShipDetailComposite(detailComposite, "Flagship");

            TargetDetailControl = new EntityDetailComposite(detailComposite, "Target");

            HighlightedDetailControl = new EntityBaseView(this);

            var layoutData = new VerticalLayoutData(FlagshipDetailControl) { GrabHorizontal = true };
            detailComposite.AddControl(layoutData);
            detailComposite.AddControl(TargetDetailControl);
            detailComposite.AddControl(HighlightedDetailControl);
            // TODO move to bottom of control

            TimeWidget = new TimeWidget(this);
            detailComposite.AddControl(TimeWidget);


            AddControl(new BoxWidget(detailComposite));
            //AddControl(detailComposite);
		}

	}
}
