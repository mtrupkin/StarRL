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
		public Entity Entity { get; protected set; }
		
		TextWidget NameWidget {get;set;}
		PointWidget PositionWidget {get;set;}
		
		public EntityDetailComposite ()
		{
			Width = 30;
			Height = 4;
			
			NameWidget = new TextWidget(){ Width=this.Width};

            PositionWidget = new PointWidget()
            {
                Enabled = false,
            };		
	
			
			LayoutManager layoutManager = new LayoutManager ();			
			layoutManager.AddControl(NameWidget);
			layoutManager.AddControl(PositionWidget);
			
			AddLayoutManager(layoutManager);
		}
		
		public override void Render ()
		{
			//Con.Clear();
						
			base.Render();
		}

        public void SetEntity(Entity entity)
        {

            if (entity != null)
            {
                NameWidget.SetText(String.Format("Name: {0}", entity.Name));
                PositionWidget.SetPoint(entity.Position);
                PositionWidget.Enabled = true;
            }
            else
            {
                NameWidget.SetText("Not Selected");
                PositionWidget.Enabled = false;
            }

            Entity = entity;
        }
	}
}
