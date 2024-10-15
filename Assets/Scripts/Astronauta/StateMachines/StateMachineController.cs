using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Astronauta.StateMachines
{
    public class StateMachineController<T> where T : Enum
    {
        public Dictionary<T, IStateMachine> stateMachines;
        public IStateMachine currentState;

        public void Init(Dictionary<T, IStateMachine> _stateMachines, T startState)
        {
            stateMachines = _stateMachines;

            if (startState != null) SwitchState(startState);
        }

        public void SwitchState(T newState)
        {
            if (currentState != null) currentState.OnStateExit();

            currentState = stateMachines[newState];
            currentState.OnStateEnter();
        }
    }
}
