using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flagship;

namespace StarRL
{
    public class FlagshipGameViewModel
    {        
        public FlagshipGame FlagshipGame { get; set; }

        // initialization for each new game
        public FlagshipGame NewGame()
        {
            GalaxyFactory galaxyFactory = new GalaxyFactory(80, 60);
            FlagshipGame.Galaxy = galaxyFactory.CreateGalaxy();

            return FlagshipGame;
        }

        public FlagshipGame LoadGame(String filename)
        {
            return null;
        }

        public void SaveGame(FlagshipGame galaxy)
        {         
        }
    }
}
