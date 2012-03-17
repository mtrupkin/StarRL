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
		public Galaxy Galaxy { get; set; }

		GalaxyScreen GalaxyScreen { get; set; }
		 
		bool paused = false;

		public GalaxyScreenViewModel (GalaxyScreen newGalaxyScreen)
		{
			GalaxyScreen = newGalaxyScreen;

			GalaxyScreen.GalaxyMasterComposite.GalaxyControl.EntitySelectedEvent += new EntityEventHandler (EntitySelectedEvent);
			GalaxyScreen.GalaxyMasterComposite.GalaxyControl.EntityHighlightedEvent += new EntityEventHandler (EntityHighlightedEvent);
			
		
			GalaxyScreen.KeyPressEvent += new KeyPressEventHandler (KeyPressedEvent);
		}
		
		void KeyPressedEvent (ConsoleKey consoleKey)
		{
			switch (consoleKey) {
			case ConsoleKey.Spacebar:
				paused = !paused;
				break;
			}
		}
		
		void EntitySelectedEvent (Entity item)
		{
			GalaxyScreen.GalaxyDetailComposite.TargetDetailControl.Entity = item;
			
			if (item != null) {
				Galaxy.Flagship.Position.Set (item.Position);
			}
		}

		void EntityHighlightedEvent (Entity item)
		{
			GalaxyScreen.GalaxyDetailComposite.HighlightedDetailControl.Entity = item;
		}
		
		bool firstTime = true;
		
		public void initialize ()
		{
			GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.Entity = Galaxy.Flagship;
		}
		
		public int Update (int duration)
		{
			if (firstTime) {
				initialize ();
				firstTime = false;
			}
			
			if (!paused) {
				Galaxy.Time += duration;
				GalaxyScreen.GalaxyDetailComposite.TimeWidget.Time = TimeSpan.FromMilliseconds (Galaxy.Time);
			}
				
			Mouse cursor = GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Mouse;
			GalaxyScreen.GalaxyDetailComposite.CursorWidget.Point.Set (cursor.X, cursor.Y);
			return duration;
		}
	}
}
