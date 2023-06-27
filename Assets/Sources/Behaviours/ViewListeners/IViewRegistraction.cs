namespace LamaGamma.Views
{
    public interface IViewRegistraction
    {
        public void Register(GameplayEntity entity);
        public void Unregister(GameplayEntity entity);
    }
}