using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLib
{
    public abstract class Shell : Composite
    {
        public string Title { get; protected set; }

        public Shell(string title, int width, int height)
            : base(width, height)           
        {
            Title = title;
        }

        public override abstract Screen CreateScreen(int width, int height);

        public abstract void Initialize();

        public abstract bool isClosed();

    }
}
