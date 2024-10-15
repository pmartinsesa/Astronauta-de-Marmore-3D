using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class MoveState : MonoBehaviour, IStateMachine
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter in move state");
        }

        public void OnStateUpdate()
        {
            transform.position += Vector3.forward * Time.deltaTime * 10;
        }

        public void OnStateExit()
        {
            Debug.Log("exit of move state");
        }
    }
}
