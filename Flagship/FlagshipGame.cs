using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{

    public delegate void GameUpdateEventHandler(int duration);

    public class FlagshipGame
    {
        public Galaxy Galaxy { get; set; }

        public bool Paused { get; set; }

        public FlagshipGame()
        {
            Paused = false;
        }

        public event GameUpdateEventHandler GameUpdateEvent;

        public int Update(int duration)
        {
            if (Galaxy != null)
            {
                if (!Paused)
                {
                    int elapsed = Galaxy.Update(duration);
                    if (GameUpdateEvent != null)
                    {
                        GameUpdateEvent(elapsed);
                    }
                    return elapsed;
                }
            } 

            return duration;
        }
    }
}
