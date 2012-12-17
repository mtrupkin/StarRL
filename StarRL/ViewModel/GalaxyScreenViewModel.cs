using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{
	public class GalaxyScreenViewModel
	{
		protected FlagshipGame FlagshipGame { get; set; }

		public FlagshipGameViewModel FlagshipGameViewModel { get; set; }

		public GalaxyScreen GalaxyScreen { get; set; }
		 
		public GalaxyScreenViewModel ()
		{
		}

        public void Initialize()
        {
            GalaxyScreen.GalaxyMasterComposite.GalaxyControl.EntitySelectedEvent += new EntityEventHandler(EntitySelectedEvent);
            GalaxyScreen.GalaxyMasterComposite.GalaxyControl.EntityHighlightedEvent += new EntityEventHandler(EntityHighlightedEvent);

            GalaxyScreen.KeyPressEvent += new KeyPressEventHandler(KeyPressedEvent);
        }

		void KeyPressedEvent (ConsoleKey consoleKey)
		{
            switch (consoleKey)
            {
                case ConsoleKey.Spacebar:
                    FlagshipGame.Pause = !FlagshipGame.Pause;
                    break;
                case ConsoleKey.Escape:
                    FlagshipGameViewModel.DisplayMainMenu();
                    break;
            }
		}
		
		void EntitySelectedEvent (Entity item)
		{
			GalaxyScreen.GalaxyDetailComposite.TargetDetailControl.SetEntity (item);
			
			if (item != null) {
				FlagshipGame.Galaxy.Flagship.Position.Set (item.Position);
                GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetShip(FlagshipGame.Galaxy.Flagship);
			}
		}

		void EntityHighlightedEvent (Entity item)
		{
			GalaxyScreen.GalaxyDetailComposite.HighlightedDetailControl.SetEntity (item);
		}
				
		public void SetFlagshipGame (FlagshipGame flagshipGame)
		{
			FlagshipGame = flagshipGame;
			var entities = new List<IDrawable<Entity>> ();

			entities.AddRange (DrawableFactory.GetDrawableStarSystems (FlagshipGame.Galaxy.StarSystems));
			entities.Add (DrawableFactory.GetDrawableShip (FlagshipGame.Galaxy.Flagship));

			GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Entities = entities;
			GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetShip (FlagshipGame.Galaxy.Flagship);
		}


		public void SetTime(TimeSpan timeSpan)
		{
            GalaxyScreen.GalaxyDetailComposite.TimeWidget.Time = timeSpan;
	    }

	}
} 
