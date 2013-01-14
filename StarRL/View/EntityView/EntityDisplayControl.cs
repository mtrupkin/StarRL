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

    public class EntityDisplayControl : ControlBase
    {
        Entity SelectedEntity { get; set; }
        Entity HighlightedEntity { get; set; }

        public override void Resize(int width, int height)
        {
            base.Resize(width, height);
        }

        public IEnumerable<IDrawable<Entity>> Entities { get; set; }
        public IDrawable<Entity> Flagship { get; set; }

        //Dictionary<Point, List<IDrawable<Entity>>> StackedEntities;

        public EntityDisplayControl(Composite parent) : base (parent)
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
            //Screen.Clear();

            //DrawJumpRadius(Flagship.Entity);
            Screen.BackgroundColor = ConsoleRGB.Space;
            Screen.ForegroundColor = ConsoleRGB.Base1;
            Screen.Clear();

            if (Entities != null)
            {
                var stackedEntities = GetStackedEntities();

                TimeSpan lastRenderTimeSpan = DateTime.Now.Subtract(lastRenderTime);

                foreach (List<IDrawable<Entity>> stack in stackedEntities.Values)
                {
                    DrawStackedEntities(stack, lastRenderTimeSpan);
                }
            }

                Screen.SetBackground(Mouse.X, Mouse.Y, ConsoleRGB.Base3);
                Screen.BackgroundColor = ConsoleRGB.Base3;
                Screen.SetPosition(Mouse.X, Mouse.Y);
                //Screen.Write((char)197);
                

                lastRenderTime = DateTime.Now;
            
        }

        void DrawJumpRadius(Entity ship)
        {
            var r = 6;
            var x = ship.Position.X;
            var y = ship.Position.Y;

            for (int i = -r; i <= r; i++)
            {
                for (int j = -r; j <= r; j++)
                {

                    if ((i * i) + (j * j) <= r * r)
                    {
                        Screen.BackgroundColor = new ConsoleRGB() { R = 40 };

                        Screen.SetPosition(x + i , y + j);
                        Screen.Write(' ');

                        Screen.BackgroundColor = ConsoleRGB.Black;
                    }
                }
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
            //ClearCrossHairs(Mouse.X, Mouse.Y);
            //DrawCrossHairs(mouse.X, mouse.Y);

            mousePosition.Set(mouse.X, mouse.Y);

            HighlightedEntity = GetEntityAt(mousePosition);

            OnEntityHighlightedEvent(HighlightedEntity);

            base.OnMouseMove(mouse);  
        }

        public void ClearCrossHairs(int x, int y)
        {
            Screen.SetPosition(x - 1, y);
            Screen.Write(' ');
            Screen.SetPosition(x + 1, y);
            Screen.Write(' ');
        }

        public void DrawCrossHairs(int x, int y)
        {
            Screen.SetPosition(x - 1, y);
            Screen.Write('[');
            Screen.SetPosition(x + 1, y);
            Screen.Write(']');
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
