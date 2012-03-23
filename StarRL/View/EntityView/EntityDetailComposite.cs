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

        TextWidget TitleWidget { get; set; }
        TextWidget NameWidget { get; set; }
        PointWidget PositionWidget { get; set; }
		
		public EntityDetailComposite (String title)
		{
			Width = 30;
			Height = 4;

            TitleWidget = new TextWidget() { Width = this.Width };
            TitleWidget.SetText(String.Format("-----{0}", title));

            NameWidget = new TextWidget() { Width = this.Width };

            PositionWidget = new PointWidget()
            {
                Enabled = false,
            };		
				
			LayoutManager layoutManager = new LayoutManager ();
            layoutManager.AddControl(TitleWidget);
			layoutManager.AddControl(NameWidget);
			layoutManager.AddControl(PositionWidget);
			
			AddLayoutManager(layoutManager);
		}

      
		public override void Render ()
		{
			//Con.Clear();
						
			base.Render();
		}

        public void SetTitle(String title)
        {
            TitleWidget.SetText(String.Format("-----{0}",title));
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
