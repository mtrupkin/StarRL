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
	public class ShipDetailComposite : Composite
	{
		public Ship Ship {get;set;}
        EntityDetailComposite EntityWidget {get;set;}
		TextWidget ShieldsWidget { get; set; }
		TextWidget TorpedoesWidget { get; set; }
		TextWidget PhasersWidget { get; set; }
		TextWidget ScannersWidget { get; set; }

		public ShipDetailComposite (String title) 
		{
			EntityWidget = new EntityDetailComposite(title);
			
			Width = EntityWidget.Width;
			Height = EntityWidget.Height + 4;
			
            ShieldsWidget = new TextWidget() { Width = this.Width };
            TorpedoesWidget = new TextWidget() { Width = this.Width };
            PhasersWidget = new TextWidget() { Width = this.Width };
            ScannersWidget = new TextWidget() { Width = this.Width };
		
			LayoutManager layoutManager = new LayoutManager ();
			layoutManager.AddControl(EntityWidget);
            layoutManager.AddControl(ShieldsWidget);
			layoutManager.AddControl(TorpedoesWidget);
			layoutManager.AddControl(PhasersWidget);
			layoutManager.AddControl(ScannersWidget);
			
			AddLayoutManager(layoutManager);
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
