using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;

namespace Libtcod
{
    class ConsoleTest
    {
        public static int Main(string[] args)
        {
            TCODConsole.initRoot(100, 75, "my game", false);
            TCODMap map = new TCODMap(100, 75); // first, create a new map.  look under fov toolkit for more on this
            for (int x = 0; x < 100; x++)
            { // time to fill in our map details
                for (int y = 0; y < 75; y++)
                {
                    map.setProperties(x, y, true, true);
                    // i'm setting the entire map to walkable.  here is where you need to set the walkable status, based on the map generated
                }
            }
            TCODPath path = new TCODPath(map, 1.0f);
            // here we create the path object, using our map.  the diagonal movement cost here is set to 1.0f
            int creatureX = 25; // TCODRandom.getInstance().getInt(0, 99); // let's start our creature at a random point
            int creatureY = 25; //TCODRandom.getInstance().getInt(0, 74);
            int destinationX = 75; //TCODRandom.getInstance().getInt(0, 99); // and let's give our beast a random destination
            int destinationY = 50; // TCODRandom.getInstance().getInt(0, 74);
            path.compute(creatureX, creatureY, destinationX, destinationY); // now we compute the path
            while (!path.isEmpty())
            { // a little while loop that ends when the destination is reached
               
                TCODConsole.root.putCharEx(creatureX, creatureY, '@', TCODColor.white, TCODColor.black);
                TCODConsole.flush();
                // here is where we draw the creature on the screen.  we won't be overwriting anything, so he'll leave a trail
                path.walk(ref creatureX, ref creatureY, true);
                // here we walk the path.  by setting the last arg to true, we'll automatically recompute the path if the path is blocked
                TCODConsole.waitForKeypress(true);
                // a little something so that you can watch the movement in a action.  just click any key to move
            }

            return 0;
        }
    }
}
            


