using Assets.Scripts.Astronauta.Core;
using Assets.Scripts.Astronauta.StateMachines;
using Assets.Scripts.Astronauta.StateMachines.Interfaces;
using Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Astronauta
{
    public class GameManager : Singleton<GameManager>
    {
        public IdleState idleState;
        public MoveState moveState;
        public JumpState jumpState;

        private enum GameStates
        {
            IDLE,
            MOVE,
            JUMP
        };

        private Dictionary<GameStates, IStateMachine> _states = new Dictionary<GameStates, IStateMachine>();
        private StateMachineController<GameStates> _stateMachineController = new StateMachineController<GameStates>();

        private void Start()
        {
            _states.Add(GameStates.IDLE, idleState);
            _states.Add(GameStates.MOVE, moveState);
            _states.Add(GameStates.JUMP, jumpState);
            InitStateMachines();
        }

        private void Update()
        {

            if (Input.GetKey(KeyCode.Space))
            {
                _stateMachineController.SwitchState(GameStates.JUMP);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                _stateMachineController.SwitchState(GameStates.MOVE);
            }
            
            _stateMachineController.RunState();

            if(_stateMachineController.currentState.Equals(GameStates.MOVE) || _stateMachineController.currentState.Equals(GameStates.JUMP))
                _stateMachineController.SwitchState(GameStates.IDLE);
        }

        private void InitStateMachines()
        {
            _stateMachineController.Init(_states, GameStates.IDLE);
        }
    }
}
