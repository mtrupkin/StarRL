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
    public class ShipDetailComposite : CompositeBase
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
            VerticalLayout layout = new VerticalLayout();
            layout.GrabHorizontal = true;

			EntityWidget = new EntityDetailComposite(this, title);
			
			
            ShieldsWidget = new TextWidget(this, "Sheilds");
            TorpedoesWidget = new TextWidget(this, "Torps");
            PhasersWidget = new TextWidget(this, "Phasers");
            ScannersWidget = new TextWidget(this, "Scanners");

            layout.AddControl(EntityWidget);
            layout.AddControl(ShieldsWidget);
            layout.AddControl(TorpedoesWidget);

            layout.AddControl(PhasersWidget, new VerticalLayoutData() { HorizontalJustify = HorizontalJustify.Right});

            layout.AddControl(ScannersWidget);

            SetLayoutManager(layout);
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
