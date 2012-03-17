using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Galaxy
    {
        public int Time { get; set; } 
        public int Height { get; set; }
        public int Width { get; set; }

        public List<StarSystem> StarSystems { get; set; }
        public Ship Flagship { get; set; }

        public Galaxy()
        {
            StarSystems = new List<StarSystem>();
        }
    }
}
