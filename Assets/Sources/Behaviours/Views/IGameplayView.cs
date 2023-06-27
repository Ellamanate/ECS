namespace LamaGamma.Views
{
    public interface IGameplayView
    {
        public GameplayEntity LinkedEntity { get; }
        public int InstanceId { get; }
        public void Initialize(Contexts contexts, GameplayEntity entity);
        public void DestroyView();
    }
}
