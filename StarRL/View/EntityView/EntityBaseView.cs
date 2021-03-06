﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using StarRL.Widget;
using Flagship;

namespace StarRL
{
    public class EntityBaseView : VerticalComposite
    {
        protected Entity Entity { get; set; }

        protected TextWidget EntityType { get; set; }
        protected TextWidget Name { get; set; }
        protected PointWidget Position { get; set; }

        public EntityBaseView(Composite parent)
            : base(parent)
        {
            EntityType = new TextWidget(this);
            Name = new TextWidget(this);
            Position = new PointWidget(this);

            AddControl(EntityType);
            AddControl(Name);
            AddControl(Position);
        }

        public void SetEntity(Entity entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
                    Name.SetText(String.Format("Name: {0}", entity.Name));
                    Position.SetPoint(entity.Position);

            Entity = entity;
        }
    }
}
