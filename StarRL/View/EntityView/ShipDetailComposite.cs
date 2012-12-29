using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;
using StarRL.Widget;

namespace StarRL
{
    public class ShipDetailComposite : VerticalComposite
	{
		public Ship Ship {get;set;}
        EntityDetailComposite EntityWidget {get;set;}
		TextWidget ShieldsWidget { get; set; }
		TextWidget TorpedoesWidget { get; set; }
		TextWidget PhasersWidget { get; set; }
		TextWidget ScannersWidget { get; set; }

        public ShipDetailComposite(Composite parent, String title)
            : base(parent, 1, 1)
		{

            EntityWidget = new EntityDetailComposite(this, title);
			
			
            ShieldsWidget = new TextWidget(this, "Sheilds");
            TorpedoesWidget = new TextWidget(this, "Torps");
            PhasersWidget = new TextWidget(this, "Phasers");
            ScannersWidget = new TextWidget(this, "Scanners");

            AddControl(EntityWidget);
            AddControl(ShieldsWidget);
            AddControl(TorpedoesWidget);

            AddControl(PhasersWidget, HorizontalJustify.Right);

            AddControl(ScannersWidget);

		}

      
		public override void Render ()
		{
			base.Render();
		}
		
        public void SetTitle(String title)
        {
            EntityWidget.SetTitle(title);
        }

        public void SetShip(Ship ship)
		{			
			EntityWidget.SetEntity(ship);
            ShieldsWidget.SetText(String.Format("Shields: {0}", ship.Shields));

            Ship = ship;
        }
	}
}
