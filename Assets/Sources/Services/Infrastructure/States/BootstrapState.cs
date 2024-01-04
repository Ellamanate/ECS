using Tymski;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly ScenesConfig _scenesConfig;

        public BootstrapState(GameStateMachine stateMachine, ScenesConfig scenesConfig)
        {
            _stateMachine = stateMachine;
            _scenesConfig = scenesConfig;
        }

        public void Enter()
        {
            _stateMachine.MoveToState<LoadingState, SceneReference>(_scenesConfig.StartScene);
        }

        public void Exit()
        {

        }

        public class Factory : PlaceholderFactory<GameStateMachine, BootstrapState> { }
    }
}
