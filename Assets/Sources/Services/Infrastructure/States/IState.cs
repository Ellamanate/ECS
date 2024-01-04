namespace LamaGamma.Infrastructure
{
    public interface IState : IExitableState
    {
        public void Enter();
    }

    public interface IState<T> : IExitableState
    {
        public void Enter(T value);
    }
}
