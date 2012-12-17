using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class Shell : AbstractComposite
    {
        public string Title { get; protected set; }                

        public Shell(string title, int width, int height):base(width, height)
        {
            Title = title;
        }

        public abstract bool isClosed();

        public override void Dispose()
        {
            base.Dispose();

            if (Screen != null)
            {
                Screen.Dispose();
                Screen = null;
                Enabled = false;
            }
        }
    }
}
