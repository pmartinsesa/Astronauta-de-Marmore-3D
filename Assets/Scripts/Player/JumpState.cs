using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class JumpState : MonoBehaviour, IStateMachine
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter in jump state");
        }

        public void OnStateUpdate()
        {
            transform.position += Vector3.up * Time.deltaTime * 10;
        }

        public void OnStateExit()
        {
            Debug.Log("exit of jump state");
        }
    }
}
