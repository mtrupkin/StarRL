using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
    public class Planet : MovableEntity
    {
        public Planet()
        {
            EntityType = EntityTypeEnum.Planet;
        }
    }
}
