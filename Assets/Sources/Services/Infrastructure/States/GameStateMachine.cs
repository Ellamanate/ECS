using System.Collections.Generic;

namespace LamaGamma.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<string, IExitableState> _states;

        private IExitableState _currentState;

        public GameStateMachine(BootstrapState.Factory bootstrapFactory, GameLoopState.Factory gameFactory,
            LoadingState.Factory loadingFactory)
        {
            _states = new Dictionary<string, IExitableState>
            {
                { nameof(BootstrapState), bootstrapFactory.Create(this) },
                { nameof(GameLoopState), gameFactory.Create(this) },
                { nameof(LoadingState), loadingFactory.Create(this) },
            };
        }

        public void MoveToState<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void MoveToState<TState, TParam>(TParam value) where TState : class, IState<TParam>
        {
            var state = ChangeState<TState>();
            state.Enter(value);
        }

        private T ChangeState<T>() where T : class, IExitableState
        {
            _currentState?.Exit();
            var state = GetState<T>();
            _currentState = state;

            return state;
        }

        private T GetState<T>() where T : class, IExitableState
        {
            string name = typeof(T).Name;
            return _states[name] as T;
        }
    }
}
