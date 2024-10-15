using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class IdleState : MonoBehaviour, IStateMachine
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter in idle state");
        }

        public void OnStateUpdate()
        {
            Debug.Log("update idle state");
        }

        public void OnStateExit()
        {
            Debug.Log("exit of idle state");
        }
    }
}
