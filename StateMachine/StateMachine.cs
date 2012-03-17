using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateMachine
{

    public class StateMachine<T> where T : IState
    {
        public T CurrentState { get; set; }

        T PreviousState { get; set; }
        T GlobalState { get; set; }

        public StateMachine()
        {
        }

        public virtual void Initialize() { }

        public int Update(int elapsedTime)
        {
            if (GlobalState != null)
            {
                GlobalState.Update(elapsedTime);
            }
            if (CurrentState != null)
            {
                elapsedTime = CurrentState.Update(elapsedTime);
            }

            return elapsedTime;
        }

        public void ChangeState(T newState)
        {
            //keep a record of the previous state
            PreviousState = CurrentState;

            //call the exit method of the existing state
            CurrentState.Exit();

            //change state to the new state
            CurrentState = newState;

            //call the entry method of the new state
            CurrentState.Enter();
        }

        //change state back to the previous state
        public void RevertToPreviousState()
        {
            ChangeState(PreviousState);
        }
    }
}
