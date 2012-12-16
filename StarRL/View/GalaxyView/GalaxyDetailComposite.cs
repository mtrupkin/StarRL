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
	public class GalaxyDetailComposite : Composite
	{
		public ShipDetailComposite FlagshipDetailControl { get; set; }

		public EntityDetailComposite TargetDetailControl { get; set; }

		public EntityDetailComposite HighlightedDetailControl { get; set; }

		public TimeWidget TimeWidget { get; set; }

		//public PointWidget CursorWidget { get; set; }

		public GalaxyDetailComposite (Composite parent): base (parent, 40, 60)
		{
			TargetDetailControl = new EntityDetailComposite (this, "Target");

            HighlightedDetailControl = new EntityDetailComposite(this, "Cursor");

            FlagshipDetailControl = new ShipDetailComposite(this, "Flagship");

			var boxControl = new BoxControl (this, "", 40, 70);

			AddControl (0, 0, boxControl);

			LayoutManager layoutManager = new LayoutManager ()
            {
                X = 1,
                Y = 1,
            };

			layoutManager.AddControl (FlagshipDetailControl);
			layoutManager.AddControl (TargetDetailControl);
			layoutManager.AddControl (HighlightedDetailControl);
            
			AddLayoutManager (layoutManager);

			TimeWidget = new TimeWidget (this);
			//CursorWidget = new PointWidget ();

			int bottomLine = boxControl.Height - 2;

			//AddControl (1, bottomLine, TimeWidget);
            AddControl(boxControl.Width - TimeWidget.Width - 1, bottomLine, TimeWidget);
		}

	}
}
