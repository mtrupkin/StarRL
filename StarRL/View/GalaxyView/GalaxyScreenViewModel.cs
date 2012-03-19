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
        public FlagshipGame FlagshipGame { get; set; }

		public GalaxyScreen GalaxyScreen { get; set; }
		 
		public GalaxyScreenViewModel ()
		{
		}
		
		void KeyPressedEvent (ConsoleKey consoleKey)
		{
			switch (consoleKey) {
			case ConsoleKey.Spacebar:
                    FlagshipGame.Paused = !FlagshipGame.Paused;
				break;
			}
		}
		
		void EntitySelectedEvent (Entity item)
		{
			GalaxyScreen.GalaxyDetailComposite.TargetDetailControl.SetEntity(item);
			
			if (item != null) {
                FlagshipGame.Galaxy.Flagship.Position.Set(item.Position);
			}
		}

		void EntityHighlightedEvent (Entity item)
		{
            GalaxyScreen.GalaxyDetailComposite.HighlightedDetailControl.SetEntity(item);
		}
				
		public void Initialize ()
		{
            var entities = new List<IDrawable<Entity>>();

            entities.AddRange(DrawableFactory.GetDrawableStarSystems(FlagshipGame.Galaxy.StarSystems));
            entities.Add(DrawableFactory.GetDrawableShip(FlagshipGame.Galaxy.Flagship));

            GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Entities = entities;

            GalaxyScreen.GalaxyMasterComposite.GalaxyControl.EntitySelectedEvent += new EntityEventHandler(EntitySelectedEvent);
            GalaxyScreen.GalaxyMasterComposite.GalaxyControl.EntityHighlightedEvent += new EntityEventHandler(EntityHighlightedEvent);


            GalaxyScreen.KeyPressEvent += new KeyPressEventHandler(KeyPressedEvent);

            FlagshipGame.GameUpdateEvent += new GameUpdateEventHandler(GameUpdateEvent);

            GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetEntity(FlagshipGame.Galaxy.Flagship);
		}

        public void GameUpdateEvent(int duration)
		{
            GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetEntity(FlagshipGame.Galaxy.Flagship);
            GalaxyScreen.GalaxyDetailComposite.TimeWidget.Time = TimeSpan.FromMilliseconds(FlagshipGame.Galaxy.Time);
				
			//Mouse cursor = GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Mouse;
			//GalaxyScreen.GalaxyDetailComposite.CursorWidget.Point.Set (cursor.X, cursor.Y);
		}
	}
}
