using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Astronauta.StateMachines
{
    public class InGameState : MonoBehaviour, IStateMachine
    {
        public GameObject player;

        public void OnStateEnter()
        {
            player.SetActive(true);
        }

        public void OnStateUpdate()
        {
            //
        }

        public void OnStateExit()
        {
            player.SetActive(false);
        }
    }
}
