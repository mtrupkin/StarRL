using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class Shell : Control
    {
        Composite Composite { get; set; }
        public string Title { get; set; }

        public Shell():base()           
        {
        }

        public abstract void Initialize();

        public abstract bool isClosed();

        public abstract IConsole CreateConsole(int width, int height);

        public override void Render()
        {
            if (Composite != null)
            {
                if (Composite.Shell == null)
                {
                    Composite.Shell = this;
                }
                Composite.Render();
                Con.Display(0, 0, Composite.Con);
            }
        }

        public virtual void SetComposite(Composite composite)
        {
            // Remove the old composite
            if (Composite != null)
            {
                Composite.Dispose();
                Composite = null;
            }

            Composite = composite;
            Composite.Shell = this;
            Composite.Con = CreateConsole(Width, Height);
            Composite.Width = Width;
            Composite.Height = Height;
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            base.OnKeyPress(consoleKey);

            if (Composite != null)
            {
                Composite.OnKeyPress(consoleKey);
            }
        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            if (Composite != null)
            {
                Composite.OnMouseMove(mouse);
            }
        }

        public override void OnMouseButton(Mouse mouse)
        {
            base.OnMouseButton(mouse);
            if (Composite != null)
            {
                Composite.OnMouseButton(mouse);
            }
        }


        public override void Dispose()
        {
            if (Composite != null)
            {
                Composite.Dispose();
            }
            if (Con != null)
            {
                Con.Dispose();
            }
        }
    }
}
