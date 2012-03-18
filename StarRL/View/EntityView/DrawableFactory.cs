using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;

namespace StarRL
{
    public class DrawableStarSystem : Drawable<StarSystem>
    {
        public DrawableStarSystem(StarSystem starSystem):base(starSystem)
        {
        }
    }

    public class DrawableFactory
    {
        public static Drawable<Ship> GetDrawableShip(Ship ship)
        {
            return new Drawable<Ship>(ship) { Icon = '@' };
        }

        public static Drawable<Star> GetDrawableStar(Star star)
        {
            return new Drawable<Star>(star);
        }

        public static List<Drawable<Star>> GetDrawableStars(List<Star> stars)
        {
            var drawableStars = new List<Drawable<Star>>();
            foreach (Star star in stars)
            {
                drawableStars.Add(GetDrawableStar(star));
            }

            return drawableStars;
        }

        public static Drawable<StarSystem> GetDrawableStarSystem(StarSystem starSystem)
        {
            return new Drawable<StarSystem>(starSystem) { Icon = '.', SelectionPriority = 1000, };
        }

        public static List<Drawable<StarSystem>> GetDrawableStarSystems(List<StarSystem> starSystems)
        {
            var drawableStarSystems = new List<Drawable<StarSystem>>();
            foreach (StarSystem starSystem in starSystems)
            {
                drawableStarSystems.Add(GetDrawableStarSystem(starSystem));
            }

            return drawableStarSystems;
        }
    }
}
