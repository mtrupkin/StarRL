using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine;
using ConsoleLib;


namespace StarRL
{
    public class ConsoleScreen : Composite, IState
    {
        public StateMachine<ConsoleScreen> StateMachine { get; set; }

        public bool Complete { get; set; }

        public void Enter() { }

        public void Exit() { }

        public virtual int Update(int duration)
        {
            Shell.Render();

            return 0;
        }

        public void ChangeScreen(ConsoleScreen newState)
        {
            newState.StateMachine = StateMachine;
            Shell.SetComposite(newState);

            StateMachine.ChangeState(newState);
        }

        public override void OnKeyPress(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.Escape)
            {
                Complete = true;
            }

            base.OnKeyPress(consoleKey);
        }
    }
}
