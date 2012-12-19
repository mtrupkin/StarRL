using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public abstract class CompositeCommon : ControlCommon, Composite
    {
        protected List<Control> Controls { get; set; }

        protected Layout LayoutManager { get; set; }

        public CompositeCommon(int width, int height)
            : base(width, height)
        {
            Controls = new List<Control>();
            LayoutManager = new VerticalLayout();
            LayoutManager.SetMinSize(Width, Height);   
        }

        public abstract Screen CreateScreen(int width, int height);
                    
        public void SetLayoutManager(Layout layout)
        {
            LayoutManager = layout;
            LayoutManager.SetMinSize(Width, Height);   
            LayoutControls();
        }

        public virtual void AddControl(Control control)
        {
            Controls.Add(control);

            if (control.IsMouseInControl(Mouse) ) {
                var mouse = control.GetMouseInControl(Mouse);
                control.Mouse.SetMouse(mouse);
            }

            LayoutControls();
        }

        public virtual void RemoveControl(Control control)
        {
            Controls.Remove(control);
            control.Dispose();

            LayoutControls();
        }

        public virtual void LayoutControls()
        {
            LayoutManager.LayoutControls(Controls);

            Resize(LayoutManager.Width, LayoutManager.Height);
        }

        public override void Render()
        {
            foreach (Control control in Controls)
            {
                if (control.Enabled)
                {
                    control.Render();
                    Screen.Display(control.X, control.Y, control.Screen);
                }
            }
        }

        public override void Dispose()
        {
            foreach (Control control in Controls)
            {
                control.Dispose();
            }
        }


        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            base.OnKeyPress(consoleKey);

            foreach (Control control in Controls)
            {
                if (control.Enabled)
                {
                    control.OnKeyPress(consoleKey);
                }
            }
        }

        public override void OnMouseMove(Mouse mouse)
        {
            base.OnMouseMove(mouse);

            foreach (Control control in Controls)
            {
                if (control.IsMouseInControl(mouse))
                {
                    var mouseInControl = control.GetMouseInControl(mouse);
                    control.OnMouseMove(mouseInControl);
                }
            }
        }

        public override void OnMouseButton(Mouse mouse)
        {
            base.OnMouseButton(mouse);

            var eventControls = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control.IsMouseInControl(mouse))                
                {
                    eventControls.Add(control);
                }
            }

            foreach (Control control in eventControls)
            {
                var mouseInControl = control.GetMouseInControl(mouse);

                control.OnMouseButton(mouseInControl);
            }
        }
    }
}
