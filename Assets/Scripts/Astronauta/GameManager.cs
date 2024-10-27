using Assets.Scripts.Astronauta.Core;
using Assets.Scripts.Astronauta.StateMachines;
using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Astronauta
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("States")]
        public InGameState inGameState;

        private enum GameStates
        {
            INGAME
        };

        private Dictionary<GameStates, IStateMachine> _states = new Dictionary<GameStates, IStateMachine>();
        private StateMachineController<GameStates> _stateMachineController = new StateMachineController<GameStates>();

        private void Start()
        {
            _states.Add(GameStates.INGAME, inGameState);
            _stateMachineController.Init(_states, GameStates.INGAME);
        }

        private void Update()
        {
            _stateMachineController.RunState();
        }
    }
}
