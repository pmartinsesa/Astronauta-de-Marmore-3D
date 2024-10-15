using Assets.Scripts.Astronauta.Core;
using Assets.Scripts.Astronauta.StateMachines;
using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using Assets.Scripts.Player;
using System.Collections.Generic;

namespace Assets.Scripts.Astronauta
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerStateMachine playerStateMachine;

        private enum GameStates
        {
            INTRO,
            PLAY,
            PAUSE,
            WIN,
            LOSE
        };

        private Dictionary<GameStates, IStateMachine> _stateMachines = new Dictionary<GameStates, IStateMachine>();
        private StateMachineController<GameStates> _stateMachineController = new StateMachineController<GameStates>();

        private void Start()
        {
            _stateMachines.Add(GameStates.INTRO, playerStateMachine);
            _stateMachines.Add(GameStates.PLAY, playerStateMachine);
            _stateMachines.Add(GameStates.PAUSE, playerStateMachine);
            _stateMachines.Add(GameStates.WIN, playerStateMachine);
            _stateMachines.Add(GameStates.LOSE, playerStateMachine);
            InitStateMachines();
        }

        private void Update()
        {
            _stateMachineController.currentState.OnStateUpdate();
        }

        private void InitStateMachines()
        {
            _stateMachineController.Init(_stateMachines, GameStates.PLAY);
        }
    }
}
