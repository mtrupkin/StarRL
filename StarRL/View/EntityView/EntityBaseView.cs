using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using StarRL.Widget;
using Flagship;

namespace StarRL
{
    public class EntityBaseView : CompositeBase
    {
        protected Entity Entity { get; set; }

        protected TextWidget EntityType { get; set; }
        protected TextWidget Name { get; set; }
        protected PointWidget Position { get; set; }

        public EntityBaseView(Composite parent)
            : base(parent, 20, 10)
        {
            EntityType = new TextWidget(this, Width);
            Name = new TextWidget(this, Width);
            Position = new PointWidget(this);

            AddControl(EntityType);
            AddControl(Name);
            AddControl(Position);
        }

        public void SetEntity(Entity entity)
        {

            if (entity != null)
            {
                Name.SetText(String.Format("Name: {0}", entity.Name));
                Position.SetPoint(entity.Position);
                Position.SetEnabled(true);
            }
            else
            {
                Name.SetText("Not Selected");
                Position.SetEnabled(false);
            }

            Entity = entity;
        }
    }
}
