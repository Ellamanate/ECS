using LamaGamma.Services;

namespace LamaGamma.Infrastructure
{
    public class MainGameServices
    {
        public InputService InputService;
        public PhysicsService PhysicsService;
        public ECSViewsRegistrator ViewsRegistrator;
        public GameEntitysRegistrator EntitysRegistrator;
    }
}
