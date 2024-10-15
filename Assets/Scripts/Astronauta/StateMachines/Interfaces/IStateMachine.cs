namespace Assets.Scripts.Astronauta.StateMachines.Interfaces
{
    public interface IStateMachine
    {
        public void OnStateEnter();
        public void OnStateUpdate();
        public void OnStateExit();
    }
}
