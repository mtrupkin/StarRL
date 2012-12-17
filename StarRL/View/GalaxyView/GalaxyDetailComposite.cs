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
    public class GalaxyDetailComposite : CompositeBase
	{
		public ShipDetailComposite FlagshipDetailControl { get; set; }

		public EntityDetailComposite TargetDetailControl { get; set; }

		public EntityBaseView HighlightedDetailControl { get; set; }

		public TimeWidget TimeWidget { get; set; }

        public GalaxyDetailComposite(Composite parent, int width, int height)
            : base(parent, width, height)
		{
            FlagshipDetailControl = new ShipDetailComposite(this, "Flagship");

			TargetDetailControl = new EntityDetailComposite (this, "Target");

            HighlightedDetailControl = new EntityBaseView(this);

			

            //SetLayoutManager(new StackedLayoutManager());

            var detailComposite = new CompositeBase(this, 39, 49);

            detailComposite.AddControl(FlagshipDetailControl);
            detailComposite.AddControl(TargetDetailControl);
            detailComposite.AddControl(HighlightedDetailControl);
            // TODO move to bottom of control
            TimeWidget = new TimeWidget(this);
            detailComposite.AddControl(TimeWidget);

            var boxControl = new BoxWidget(detailComposite, "");
            AddControl(boxControl);

		}

	}
}
