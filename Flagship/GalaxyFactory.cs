using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flagship
{
	public class GalaxyFactory
	{
		public static int MAX_STARS = 100;

		public int Width { get; private set; }

		public int Height { get; private set; }

		public GalaxyFactory (int width, int height)
		{
			Width = width;
			Height = height;
		}

		public Ship CreateFlagship ()
		{
			Ship flagship = new Ship ()
            {
                Position = RandomPoint(),
                Name = "Flagship",

            };

			return flagship;
		}

		public Star CreateStar ()
		{
			Star newStar = new Star ()
            {
                Name = RandomString(10),                
            };

			return newStar;
		}

		public StarSystem CreateStarSystem ()
		{
			StarSystem newStarSystem = new StarSystem (CreateStar ())
            {
                Position = RandomPoint(),

            };

			return newStarSystem;
		}

		public Galaxy CreateGalaxy ()
		{
			Galaxy newGalaxy = new Galaxy ()
            {
                Width = Width,
                Height = Height,
            };

			for (int i = 0; i < MAX_STARS; i++) {
				newGalaxy.StarSystems.Add (CreateStarSystem ());
			}

			int flagshipStarSystemIndex = _rng.Next (MAX_STARS);
			Ship flagship = CreateFlagship();
			
			newGalaxy.Flagship = flagship;
			newGalaxy.StarSystems[flagshipStarSystemIndex].Ships.Add(flagship);
			
			return newGalaxy;
		}

		private static readonly Random _rng = new Random ((int)DateTime.Now.Ticks);
		private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		private string RandomString (int size)
		{
			char[] buffer = new char[size];

			for (int i = 0; i < size; i++) {
				buffer [i] = _chars [_rng.Next (_chars.Length)];
			}
			return new string (buffer);
		}

		private Point RandomPoint ()
		{
			Point newPoint = new Point ()
            {
                X = _rng.Next(Width),
                Y = _rng.Next(Height),
            };

			return newPoint;
		}
	}
}
