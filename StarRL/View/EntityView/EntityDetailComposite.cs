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
	public class EntityDetailComposite : Composite
	{
		public Entity Entity { get; set; }
		
		TextWidget NameWidget {get;set;}
		PointWidget PositionWidget {get;set;}
		
		public EntityDetailComposite ()
		{
			Width = 30;
			Height = 4;
			
			NameWidget = new TextWidget(){ Width=this.Width};
			
			PositionWidget = new PointWidget();			
			
			LayoutManager layoutManager = new LayoutManager ();			
			layoutManager.AddControl(NameWidget);
			layoutManager.AddControl(PositionWidget);
			
			AddLayoutManager(layoutManager);
		}
		
		public override void Render ()
		{
			Con.Clear();
			
			if (Entity != null) {                
				NameWidget.TextValue = String.Format ("Name: {0}", Entity.Name);

                PositionWidget.Enabled = true;
				PositionWidget.Point.Set(Entity.Position);
			} else {
				NameWidget.TextValue = "Not Selected";
                PositionWidget.Enabled = false;
			}
			
			base.Render();
		}
	}
}
