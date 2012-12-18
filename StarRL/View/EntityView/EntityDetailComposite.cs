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
    public class EntityDetailComposite : CompositeBase
	{
        
		public Entity Entity { get; protected set; }

        TextWidget TitleWidget { get; set; }
        TextWidget NameWidget { get; set; }
        PointWidget PositionWidget { get; set; }
		
		public EntityDetailComposite (Composite parent, String title) : base (parent, 30, 4)
		{

            TitleWidget = new TextWidget(this, String.Format("-----{0}-----", title));

            NameWidget = new TextWidget(this, 20);

            PositionWidget = new PointWidget(this);
            PositionWidget.SetEnabled(false);
				
            AddControl(TitleWidget);
			AddControl(NameWidget);
			AddControl(PositionWidget);			
		}
      
		public override void Render ()
		{
						
			base.Render();
		}

        public void SetTitle(String title)
        {
            TitleWidget.SetText(String.Format("-----{0}-----",title));
        }

        public void SetEntity(Entity entity)
        {

            if (entity != null)
            {
                NameWidget.SetText(String.Format("Name: {0}", entity.Name));
                PositionWidget.SetPoint(entity.Position);
                PositionWidget.SetEnabled(true);
            }
            else
            {
                NameWidget.SetText("Not Selected");
                PositionWidget.SetEnabled(false);
            }

            Entity = entity;
        }
	}
}
