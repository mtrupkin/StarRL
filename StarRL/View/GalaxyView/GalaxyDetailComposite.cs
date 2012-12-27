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
            var detailComposite = new CompositeBase(this, 1, 1);

            VerticalLayout layout = new VerticalLayout();

            FlagshipDetailControl = new ShipDetailComposite(detailComposite, "Flagship");

            TargetDetailControl = new EntityDetailComposite(detailComposite, "Target");

            HighlightedDetailControl = new EntityBaseView(this);

            layout.AddControl(FlagshipDetailControl);
            layout.AddControl(TargetDetailControl);
            layout.AddControl(HighlightedDetailControl);
            // TODO move to bottom of control

            TimeWidget = new TimeWidget(this);
            layout.AddControl(TimeWidget);

            detailComposite.SetLayoutManager(layout);

            AddControl(detailComposite);
		}

	}
}
