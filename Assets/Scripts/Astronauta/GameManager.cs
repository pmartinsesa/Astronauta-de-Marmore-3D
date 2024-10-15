using Assets.Scripts.Astronauta.Core;
using Assets.Scripts.Astronauta.StateMachines;
using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using Assets.Scripts.Player;
using System.Collections.Generic;

namespace Assets.Scripts.Astronauta
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerState playerStateMachine;

        private enum GameStates
        {
            INTRO,
            PLAY,
            PAUSE,
            WIN,
            LOSE
        };

        private Dictionary<GameStates, IStateMachine> _states = new Dictionary<GameStates, IStateMachine>();
        private StateMachineController<GameStates> _stateMachineController = new StateMachineController<GameStates>();

        private void Start()
        {
            _states.Add(GameStates.INTRO, playerStateMachine);
            _states.Add(GameStates.PLAY, playerStateMachine);
            _states.Add(GameStates.PAUSE, playerStateMachine);
            _states.Add(GameStates.WIN, playerStateMachine);
            _states.Add(GameStates.LOSE, playerStateMachine);
            InitStateMachines();
        }

        private void Update()
        {
            _stateMachineController.currentState.OnStateUpdate();
        }

        private void InitStateMachines()
        {
            _stateMachineController.Init(_states, GameStates.PLAY);
        }
    }
}
