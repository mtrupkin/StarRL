using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public class StackedComposite : CompositeBase<LayoutData>
    {
        public StackedComposite(Composite parent) : base(parent) { }

        public override void AddControl(Control control)
        {
            var layoutData = new LayoutData(control);

            AddControl(layoutData);
        }

        public void AddControl(LayoutData layoutData)
        {
            ControlData.Add(layoutData);
        }

    }
}
