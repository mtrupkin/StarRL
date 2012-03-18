using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;

namespace StarRL
{
    public interface IDrawable<out T> where T : Entity
    {
         T Entity { get; }
         char Icon { get; set; }

         int SelectionPriority { get; set; }

         void Draw();
    }
}
