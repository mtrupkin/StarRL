using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{ 

    public abstract class Composite : Control
    {
        protected List<ControlLayout> Controls { get; set; }

        protected Composite(int width, int height) : base(width, height)
        {
            Controls = new List<ControlLayout>();
        }

        protected Composite(Composite parent):this(parent, 0, 0)
        {            
        }

        public Composite(Composite parent, int width, int height) : base(parent, width, height)
        {
            Controls = new List<ControlLayout>();
        }

        public virtual Screen CreateScreen(int width, int height)
        {
            return Parent.CreateScreen(width, height);
        }

        public virtual void AddControl(Control control)
        {
            AddControl(0, 0, control);
        }

        public virtual void AddControl(int x, int y, Control control)
        {
            if (control != null)
            {
                ControlLayout layout = new ControlLayout(control)
                {
                    X = x,
                    Y = y,
                };

                AddLayout(layout);
            }
        }

        public virtual void AddLayout(ControlLayout layout)
        {
            Control control = layout.Control;

            if ((control.Width == 0) && (control.Height == 0))
            {
                // set the size of the control to the parent's size               
                control.Width = Width;
                control.Height = Height;
            }

            Mouse newMouse = MouseInControl(layout, Mouse);
            if (newMouse != null)
            {
                control.Mouse.X = newMouse.X;
                control.Mouse.Y = newMouse.Y;
            }

            Controls.Add(layout);        
        }

        public virtual void AddLayoutManager(LayoutManager layoutManager)
        {
            foreach (ControlLayout layout in layoutManager.GetLayouts())
            {
                AddLayout(layout);
            }
        }

        // ???
        public virtual void AddComposite(int x, int y, Composite control)
        {
            if (control != null)
            {
                control.Parent = this;
                if ((control.Width == 0) && (control.Height == 0))
                {
                    // set the size of the control to the parent's size               
                    control.Width = Width;
                    control.Height = Height;
                }

                ControlLayout layout = new ControlLayout(control)
                {
                    X = x,
                    Y = y,
                };

                Mouse newMouse = MouseInControl(layout, Mouse);
                if (newMouse != null)
                {
                    control.Mouse.X = newMouse.X;
                    control.Mouse.Y = newMouse.Y;
                }

                Controls.Add(layout);
            }
        }

        public virtual void RemoveControl(Control control)
        {
            ControlLayout removeLayout = null;
            foreach (ControlLayout layout in Controls)
            {
                if (layout.Control.Equals(control))
                {
                    removeLayout = layout;
                }
            }
            if (removeLayout != null)
            {
                removeLayout.Control.Dispose();
                Controls.Remove(removeLayout);
            }
        }


        public override void Render()
        {
            foreach (ControlLayout layout in Controls)
            {
                if (layout.Control.Enabled)
                {
                    layout.Control.Render();
                    Screen.Display(layout.X, layout.Y, layout.Control.Screen);
                }
            }
        }

        public override void Dispose()
        {
            if (Screen != null)
            {
                Screen.Dispose();
                Screen = null;
            }
            foreach (ControlLayout layout in Controls)
            {
                layout.Control.Dispose();
            }
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            // leaving in case widgets emit key events when in focus
            base.OnKeyPress(consoleKey);

            foreach (ControlLayout layout in Controls)
            {
                if (layout.Control.Enabled)
                {
                    layout.Control.OnKeyPress(consoleKey);
                }
            }
        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            foreach (ControlLayout layout in Controls)
            {
                Mouse newMouse = MouseInControl(layout, mouse);
                if (newMouse != null) {
                    if (layout.Control.Enabled)
                    {
                        layout.Control.OnMouseMove(newMouse);
                    }
                }
            }
        }

        public override void OnMouseButton(Mouse mouse)
        {
            base.OnMouseButton(mouse);

            var enabledControls = new List<ControlLayout>();

            foreach (ControlLayout layout in Controls)
            {
                Mouse newMouse = MouseInControl(layout, mouse);
                if (newMouse != null)
                {
                    if (layout.Control.Enabled)
                    {
                        enabledControls.Add(layout);
                    }
                }
            }

            foreach (ControlLayout layout in enabledControls)
            {
                Mouse newMouse = MouseInControl(layout, mouse);
                if (newMouse != null)
                {
                    layout.Control.OnMouseButton(newMouse);
                }

            }
        }

        Mouse MouseInControl(ControlLayout layout, Mouse mouse)
        {
            Mouse newMouse = null;
            if (layout.Control.Enabled)
            {
                if ((mouse.X >= layout.X) &&
                     (mouse.Y >= layout.Y) &&
                     (mouse.X < (layout.X + layout.Control.Width)) &&
                     (mouse.Y < (layout.Y + layout.Control.Height)))
                {
                    newMouse = new Mouse()
                    {
                        X = mouse.X - layout.X,
                        Y = mouse.Y - layout.Y,
                        LeftButton = mouse.LeftButton,
                    };
                }
            }

            return newMouse;
        }


    }
}
