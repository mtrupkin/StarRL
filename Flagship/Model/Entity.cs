using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Entity
    {
        public EntityTypeEnum EntityType { get; set; }
        public String Name { get; set; }
        public Point Position { get; set; }
        public int Radius { get; set; }

        public Entity()
        {
            EntityType = EntityTypeEnum.Space;
            Name = "Space";
            Radius = 1;
        }
    }
}
