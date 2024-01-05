using Zenject;

namespace LamaGamma.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public class Factory : PlaceholderFactory<GameStateMachine, GameLoopState> { }
    }
}
