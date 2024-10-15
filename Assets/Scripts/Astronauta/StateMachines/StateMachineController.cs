using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Astronauta.StateMachines
{
    public class StateMachineController<T> where T : Enum
    {
        public Dictionary<T, IStateMachine> stateMachines;
        public T currentState;

        public void Init(Dictionary<T, IStateMachine> _stateMachines, T startState)
        {
            stateMachines = _stateMachines;

            if (startState != null) SwitchState(startState);
        }

        public void SwitchState(T newState)
        {
            if (currentState != null) stateMachines[currentState].OnStateExit();

            currentState = newState;
            stateMachines[currentState].OnStateEnter();
        }

        public void RunState()
        {
            stateMachines[currentState].OnStateUpdate();
        }
    }
}
