using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class FlagshipGame
    {

        public Galaxy Galaxy { get; set; }

        public bool Pause { get; set; }

        public bool Complete { get; set; }

        public FlagshipGame()
        {
            Pause = false;
            Complete = false;
        }

        public int Update(int duration)
        {
            if (Galaxy != null)
            {
                if (!Pause)
                {
                    return Galaxy.Update(duration);
                }
            } 

            return duration;
        }
    }
}
