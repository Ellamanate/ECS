using LamaGamma.Infrastructure;

namespace LamaGamma.Systems
{
    public class RootSystems : Feature
    {
        public RootSystems(Contexts contexts, MainGameServices services)
        {
            Add(new GameEventSystems(contexts));
            Add(new ServiceRegistrationSystems(contexts, services));

            Add(new InputSystems(contexts.input));

            Add(new PlayerMoveSystem(contexts));
            Add(new LogHealthSystem(contexts));
        }
    }
}
