using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;

namespace StarRL.Widget
{
    public class TimeWidget : Control
    {
        public TimeSpan Time { get; set; }

        public TimeWidget()
        {
            Width = 14;
            Height = 1;
        } 

        public override void Render()
        {
            {
                //Con.SetPosition(0, 0);
                //Con.Write(String.Format("[{0,2}:{1,2}:{2,2}]", Time.Hours, Time.Minutes, Time.Seconds));
                Con.Write(Time.ToString(@"\[hh\:mm\:ss\]"));
                //Con.Write(Time.ToString("c"));
            }
        }
    }
}
