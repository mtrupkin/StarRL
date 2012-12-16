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

        public IEnumerable<IDrawable<Entity>> Entities { get; set; }

        //Dictionary<Point, List<IDrawable<Entity>>> StackedEntities;

        public EntityDisplayControl(Composite parent, int width, int height) : base (parent, width, height)
        {
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

        DateTime lastRenderTime = DateTime.Now;

        public override void Render()
        {
            Screen.Clear();

            if (Entities != null)
            {
                var stackedEntities = GetStackedEntities();

                TimeSpan lastRenderTimeSpan = DateTime.Now.Subtract(lastRenderTime);

                foreach (List<IDrawable<Entity>> stack in stackedEntities.Values)
                {
                    DrawStackedEntities(stack, lastRenderTimeSpan);
                }

                // render mouse?
                Screen.SetPosition(Mouse.X, Mouse.Y);
                Screen.Write('X');

                lastRenderTime = DateTime.Now;
            }
        }

        void DrawStackedEntities(List<IDrawable<Entity>> stack, TimeSpan lastRenderTimeSpan)
        {             
            int stackCount = stack.Count;
            int drawIndex = ((lastRenderTime.Millisecond / 500 ) % stackCount);
            DrawEntity(stack[drawIndex]);
        }

        void DrawEntity(IDrawable<Entity> drawableEntity)
        {
            Screen.SetPosition(drawableEntity.Entity.Position.X, drawableEntity.Entity.Position.Y);
            Screen.Write(drawableEntity.Icon);  
        }

        Point mousePosition = new Point();

        Entity GetEntityAt(Point position)
        {

            if (Entities != null)
            {
                var stackedEntities = GetStackedEntities();
                List<IDrawable<Entity>> stack = new List<IDrawable<Entity>>();

                if (stackedEntities.TryGetValue(position, out stack))
                {
                    stack.Sort(SelectionPriorityComparer.DEFAULT);
                    return stack[0].Entity;
                }
            }

            return new Entity() { Position = new Point(mousePosition) };
        }

        public override void OnMouseMove(Mouse mouse)
        {
            Screen.SetPosition(Mouse.X, Mouse.Y);
            Screen.Write(' ');

            Screen.SetPosition(mouse.X, mouse.Y);
            Screen.Write('X');

            mousePosition.Set(mouse.X, mouse.Y);

            HighlightedEntity = GetEntityAt(mousePosition);

            OnEntityHighlightedEvent(HighlightedEntity);
            
            base.OnMouseMove(mouse);
        }

        public override void OnMouseButton(Mouse mouse)
        {
            mousePosition.Set(mouse.X, mouse.Y);

            SelectedEntity = GetEntityAt(mousePosition);

            OnEntitySelectedEvent(SelectedEntity);            

            base.OnMouseButton(mouse);
        }
    }
}
