using ConsoleLib;
using StarRL.Widget;

namespace StarRL
{
    public class SystemDetailComposite: StackedComposite
	{
		public ShipDetailComposite FlagshipDetailControl { get; set; }

        public EntityBaseView TargetDetailControl { get; set; }

		public TimeWidget TimeWidget { get; set; }

        public SystemDetailComposite(Composite parent)
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
