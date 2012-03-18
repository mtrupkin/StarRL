using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;
using System.Collections;

namespace StarRL
{
    public delegate void EntityEventHandler(Entity item);

    public class SelectionPriorityComparer : IComparer<IDrawable<Entity>>
    {
        public static SelectionPriorityComparer DEFAULT = new SelectionPriorityComparer();

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(IDrawable<Entity> e1, IDrawable<Entity> e2)
        {

            if ((e1 != null) && (e2 != null))
            {
                return e2.SelectionPriority - e1.SelectionPriority;
            }

            throw new NullReferenceException();
            
        }

    }

    public class EntityDisplayControl : Control
    {
        Entity SelectedEntity { get; set; }
        Entity HighlightedEntity { get; set; }

        IEnumerable<IDrawable<Entity>> Entities { get; set; }

        Dictionary<Point, List<IDrawable<Entity>>> StackedEntities;

        public EntityDisplayControl(IEnumerable<IDrawable<Entity>> newEntities)
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

        int renderCount = 1;


        Dictionary<Point, List<IDrawable<Entity>>> GetStackedEntities()
        {

            var stackedEntities = new Dictionary<Point, List<IDrawable<Entity>>>();

            foreach (IDrawable<Entity> o in Entities)
            {
                var position = o.Entity.Position;
                if (!stackedEntities.ContainsKey(position))
                {
                    stackedEntities[position] = new List<IDrawable<Entity>>();
                }

                stackedEntities[position].Add(o);
            }

            return stackedEntities;
        }

        public override void Render()
        {

            var stackedEntities = GetStackedEntities();

            foreach (List<IDrawable<Entity>> stack in stackedEntities.Values)
            {
                int stackCount = stack.Count;
                int drawIndex = (renderCount % stackCount);
                DrawEntity(stack[drawIndex]);
            }

            renderCount++;

            // render mouse?
            Con.SetPosition(Mouse.X, Mouse.Y);
            Con.Write('X');

        }

        void DrawEntity(IDrawable<Entity> drawableEntity)
        {
            Con.SetPosition(drawableEntity.Entity.Position.X, drawableEntity.Entity.Position.Y);
            Con.Write(drawableEntity.Icon);  
        }

        Point mousePosition = new Point();

        public override void OnMouseMove(Mouse mouse)
        {
            Con.SetPosition(Mouse.X, Mouse.Y);
            Con.Write(' ');

            Con.SetPosition(mouse.X, mouse.Y);
            Con.Write('X');

            Entity currentEntity = HighlightedEntity;
            HighlightedEntity = null;

            var stackedEntities = GetStackedEntities();

            mousePosition.X = mouse.X;
            mousePosition.Y = mouse.Y;

            List<IDrawable<Entity>> stack = new List<IDrawable<Entity>>();

            if (stackedEntities.TryGetValue(mousePosition, out stack))
            {
                stack.Sort(SelectionPriorityComparer.DEFAULT);
                HighlightedEntity = stack[0].Entity;
                OnEntityHighlightedEvent(HighlightedEntity);
            }

            if ((currentEntity != null) && (HighlightedEntity == null))
            {
                OnEntityHighlightedEvent(HighlightedEntity);
            }

            base.OnMouseMove(mouse);
        }

        public override void OnMouseButton(Mouse mouse)
        {
            Entity currentEntity = SelectedEntity;
            SelectedEntity = null;

            var stackedEntities = GetStackedEntities();

            mousePosition.X = mouse.X;
            mousePosition.Y = mouse.Y;

            List<IDrawable<Entity>> stack = new List<IDrawable<Entity>>();

            if (stackedEntities.TryGetValue(mousePosition, out stack))
            {
                stack.Sort(SelectionPriorityComparer.DEFAULT);
                SelectedEntity = stack[0].Entity;
                OnEntitySelectedEvent(SelectedEntity);
            }

            if ((currentEntity != null) && (SelectedEntity == null))
            {
                OnEntitySelectedEvent(SelectedEntity);
            }

            base.OnMouseButton(mouse);
        }
    }
}
