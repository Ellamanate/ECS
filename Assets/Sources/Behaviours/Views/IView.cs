namespace LamaGamma.Views
{
    public interface IView
    {
        public GameEntity LinkedEntity { get; }
        public int InstanceId { get; }
        public void Initialize(Contexts contexts, GameEntity entity);
        public void DestroyView();
    }
}
