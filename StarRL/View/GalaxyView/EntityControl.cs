using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{
    public delegate void EntityEventHandler(Entity item);

    public class EntityDisplayControl : Control
    {
        Entity SelectedEntity { get; set; }
        Entity HighlightedEntity { get; set; }

        IEnumerable<Entity> Entities { get; set; }

        public EntityDisplayControl(IEnumerable<Entity> newEntities)
        {
            Entities = newEntities;
        }

        public event EntityEventHandler EntitySelectedEvent;
        public event EntityEventHandler EntityHighlightedEvent;

        public virtual void OnEntitySelectedEvent(Entity item)
        {
            if (EntitySelectedEvent != null)
            {
                EntitySelectedEvent(item);
            }
        }

        public virtual void OnEntityHighlightedEvent(Entity item)
        {
            if (EntityHighlightedEvent != null)
            {
                EntityHighlightedEvent(item);
            }
        }

        public override void Render()
        {            
            foreach (Entity o in Entities)
            {
                Con.SetPosition(o.Position.X, o.Position.Y);
                Con.Write('*');                
            }
        }

        public override void OnMouseMove(Mouse mouse)
        {
            Con.SetPosition(Mouse.X, Mouse.Y);
            Con.Write(' ');

            Con.SetPosition(mouse.X, mouse.Y);
            Con.Write('X');

            Entity currentEntity = HighlightedEntity;
            HighlightedEntity = null;

            foreach (Entity o in Entities)
            {
                if ((o.Position.X == mouse.X) && (o.Position.Y == mouse.Y))
                {
                    HighlightedEntity = o;
                    OnEntityHighlightedEvent(o);
                }
            }

            if ((currentEntity != null) && (HighlightedEntity == null) )
            {
                OnEntityHighlightedEvent(HighlightedEntity);
            }

            base.OnMouseMove(mouse);
        }

        public override void OnMouseButton(Mouse mouse)
        {
            Entity currentEntity = SelectedEntity;
            SelectedEntity = null;

            foreach (Entity o in Entities)
            {
                if ((o.Position.X == mouse.X) && (o.Position.Y == mouse.Y))
                {
                    SelectedEntity = o;
                    OnEntitySelectedEvent(o);
                }
            }

            if ((currentEntity != null) && (SelectedEntity == null))
            {
                OnEntitySelectedEvent(SelectedEntity);
            }

            base.OnMouseButton(mouse);
        }
    }
}
