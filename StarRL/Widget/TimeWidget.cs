using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;

namespace StarRL.Widget
{
    public class TimeWidget : ControlBase
    {
        public TimeSpan Time { get; set; }

        public TimeWidget(Composite parent) : base(parent, 10, 1)
        {
        }

        public override void Render()
        {
            {
                //Con.SetPosition(0, 0);
                //Con.Write(String.Format("[{0,2}:{1,2}:{2,2}]", Time.Hours, Time.Minutes, Time.Seconds));
                Screen.Write(Time.ToString(@"\[hh\:mm\:ss\]"));
                //Con.Write(Time.ToString("c"));                
            }
        }
    }
}
