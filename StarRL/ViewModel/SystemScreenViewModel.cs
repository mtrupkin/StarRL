using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLib;
using ConsoleLib.Widget;
using Flagship;

namespace StarRL
{
	public class SystemScreenViewModel
	{
		protected FlagshipGame FlagshipGame { get; set; }

		public FlagshipGameViewModel FlagshipGameViewModel { get; set; }

        public SystemScreen SystemScreen { get; set; }

        public SystemScreenViewModel(FlagshipGameViewModel flagshipGameViewModel, SystemScreen systemScreen)
		{
            FlagshipGameViewModel = flagshipGameViewModel;
            SystemScreen = systemScreen;
            Initialize();
		}

        public void Initialize()
        {
            //SystemScreen.SystemMasterComposite.SystemControl.EntitySelectedEvent += new EntityEventHandler(EntitySelectedEvent);
            SystemScreen.SystemMasterComposite.SystemControl.EntityHighlightedEvent += new EntityEventHandler(EntityHighlightedEvent);

            SystemScreen.KeyPressEvent += new KeyPressEventHandler(KeyPressedEvent);
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
		
        //void EntitySelectedEvent (Entity item)
        //{
        //    GalaxyScreen.GalaxyDetailComposite.TargetDetailControl.SetEntity (item);
			
        //    if (item != null) {
        //        FlagshipGame.Galaxy.Flagship.Position.Set (item.Position);
        //        GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetShip(FlagshipGame.Galaxy.Flagship);
        //    }
        //}

        
        void EntityHighlightedEvent (Entity item)
        {
          // GalaxyScreen.GalaxyDetailComposite.TargetDetailControl.SetEntity (item);
        }
				
        //public void SetFlagshipGame (FlagshipGame flagshipGame)
        //{
        //    FlagshipGame = flagshipGame;
        //    var entities = new List<IDrawable<Entity>> ();

        //    entities.AddRange (DrawableFactory.GetDrawableStarSystems (FlagshipGame.Galaxy.StarSystems));
        //    entities.Add (DrawableFactory.GetDrawableShip (FlagshipGame.Galaxy.Flagship));

            

        //    GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Entities = entities;
        //    GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Flagship = DrawableFactory.GetDrawableShip(FlagshipGame.Galaxy.Flagship);

        //    GalaxyScreen.GalaxyMasterComposite.GalaxyControl.Resize(FlagshipGame.Galaxy.Width, FlagshipGame.Galaxy.Height);

            
        //    GalaxyScreen.GalaxyDetailComposite.FlagshipDetailControl.SetShip (FlagshipGame.Galaxy.Flagship);

        //    GalaxyScreen.Resize();
        //}


	}
} 
