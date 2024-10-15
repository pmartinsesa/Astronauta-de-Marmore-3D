using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStateMachine : MonoBehaviour, IStateMachine
    {
        public void OnStateEnter()
        {
            Debug.Log("Enter in player ms");
        }

        public void OnStateUpdate()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.forward * Time.deltaTime * 10;
                return;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += Vector3.up * Time.deltaTime * 10;
                return;
            }
        }

        public void OnStateExit()
        {
            Debug.Log("exit of player ms");
        }
    }
}
