using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{

    public class CompositeBase : ControlBase, Composite
    {
        protected List<Control> Controls { get; set; }

        protected Layout LayoutManager { get; set; }

        public CompositeBase(Control parent, int width, int height)
            : base(parent, width, height)
        {
            Controls = new List<Control>();
            LayoutManager = new VerticalLayout();
        }
                    
        public void SetLayoutManager(Layout layout)
        {
            LayoutManager = layout;

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
            base.Dispose();

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

            foreach (Control control in Controls)
            {
                if (control.IsMouseInControl(mouse))                
                {
                    var mouseInControl = control.GetMouseInControl(mouse);

                    control.OnMouseButton(mouseInControl);
                }
            }
        }
    }
}
