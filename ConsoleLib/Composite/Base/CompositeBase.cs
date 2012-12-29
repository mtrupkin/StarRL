using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class CompositeBase<T> : CompositeCommon<T>, Composite where T : LayoutData
    {
      
        public CompositeBase(Composite parent, int width, int height)
            : base(width, height)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            Parent = parent;
            Screen = Parent.CreateScreen(width, height);

        }        

        public override Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public override void Render()
        {
            foreach (LayoutData layoutData in ControlData)
            {
                Control control = layoutData.Control;
                if (control.Enabled)
                {
                    control.Render();
                    Screen.Display(layoutData.X, layoutData.Y, control.Screen);
                }
            }
        }

        public override void Resize(int width, int height, bool notify)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            if ((width != Width) || (height != Height))
            {
                Screen.Dispose();
                Screen = Parent.CreateScreen(width, height);

                Width = width;
                Height = height;

                foreach (LayoutData layoutData in ControlData)
                {
                    Control control = layoutData.Control;
                    if (control.Enabled)
                    {
                        if (layoutData.GrabExcess)
                        {
                            control.Resize(Width, Height, false);
                        }
                    }
                }

                if (notify)
                {
                    Parent.Resize();
                }
            }
        }
    }
}
