using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateMachine
{
    public interface IState
    {
        void Enter();

        int Update(int elapsedTime);

        void Exit();
    }
}
