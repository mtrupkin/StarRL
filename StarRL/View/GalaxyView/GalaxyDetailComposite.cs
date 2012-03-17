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
		public EntityDetailComposite FlagshipDetailControl { get; set; }

		public EntityDetailComposite TargetDetailControl { get; set; }

		public EntityDetailComposite HighlightedDetailControl { get; set; }

		public TimeWidget TimeWidget { get; set; }

		public PointWidget CursorWidget { get; set; }

		public GalaxyDetailComposite ()
		{
			TargetDetailControl = new EntityDetailComposite ();

			HighlightedDetailControl = new EntityDetailComposite ();

			FlagshipDetailControl = new EntityDetailComposite ();

			var boxControl = new BoxControl ()
            {
                //Title = "Galaxy Detail",
                Width = 40,
                Height = 60,
            };

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

			TimeWidget = new TimeWidget ();
			CursorWidget = new PointWidget ();

			int bottomLine = boxControl.Height - 2;

			AddControl (1, bottomLine, TimeWidget);
			AddControl (boxControl.Width - CursorWidget.Width - 1, bottomLine, CursorWidget);
		}

	}
}
