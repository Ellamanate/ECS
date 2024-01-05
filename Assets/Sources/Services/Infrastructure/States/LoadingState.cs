using Cysharp.Threading.Tasks;
using Tymski;
using UnityEngine.SceneManagement;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class LoadingState : IState<SceneReference>
    {
        private readonly GameStateMachine _stateMachine;

        public LoadingState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter(SceneReference value)
        {
            _ = LoadScene(value);
        }

        public void Exit()
        {

        }

        public async UniTaskVoid LoadScene(SceneReference scene)
        {
            await SceneManager.LoadSceneAsync(scene);

            _stateMachine.MoveToState<GameLoopState>();
        }

        public class Factory : PlaceholderFactory<GameStateMachine, LoadingState> { }
    }
}
