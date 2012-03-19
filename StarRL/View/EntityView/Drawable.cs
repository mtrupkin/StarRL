using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;

namespace StarRL
{
    public class Drawable<T> : IDrawable<T> where T : Entity
    {
        public int EntityType { get; set; }

        public T Entity { get; set; }
        public char Icon { get; set; }

        public int SelectionPriority { get; set; }

        public Drawable(T entity)
        {
            Entity = entity;
            Icon = '.';
            SelectionPriority = 0;
        }

        public virtual void Draw()
        {
        }
    }
}
