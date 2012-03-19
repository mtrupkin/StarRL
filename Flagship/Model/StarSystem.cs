using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class StarSystem : Entity
    {
        public Star Star { get; set; }

        public List<Planet> Planets { get; set; }
        public List<Ship> Ships { get; set; }

        public StarSystem(Star newStar)
        {
            EntityType = EntityTypeEnum.StarSystem;

            Star = newStar;
            Name = Star.Name;
			
			Planets = new List<Planet>();
			Ships = new List<Ship>();
        }

    }
}
