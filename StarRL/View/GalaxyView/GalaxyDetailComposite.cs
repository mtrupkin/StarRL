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
    public class GalaxyDetailComposite : StackedComposite
	{
		public ShipDetailComposite FlagshipDetailControl { get; set; }

        public EntityBaseView TargetDetailControl { get; set; }

		public TimeWidget TimeWidget { get; set; } 

        public GalaxyDetailComposite(Composite parent)
            : base(parent)
		{
            var detailComposite = new VerticalComposite(this);

            FlagshipDetailControl = new ShipDetailComposite(detailComposite, "Flagship") { GrabHorizontal = true };
            TargetDetailControl = new EntityBaseView(detailComposite);

            detailComposite.AddControl(FlagshipDetailControl);
            detailComposite.AddControl(TargetDetailControl);

            AddControl(detailComposite);

            // TODO move to bottom of control
            
            TimeWidget = new TimeWidget(this);
            var timeLayout = new VerticalLayoutData(TimeWidget) { VerticalJustify = VerticalJustify.Bottom, HorizontalJustify = HorizontalJustify.Right };
            AddControl(timeLayout);
            
		}

	}
}
