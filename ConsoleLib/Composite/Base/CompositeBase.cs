using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class CompositeBase<T> : CompositeCommon<T>, Composite where T : LayoutData
    {
      
        public CompositeBase(Composite parent)
            : base()
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            Parent = parent;
            Screen = Parent.CreateScreen(1, 1);

        }        

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }        

        public override void Resize()
        {
            Parent.Resize();
        }
    }
}
