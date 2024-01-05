using LamaGamma.Infrastructure;

namespace LamaGamma.Systems
{
    public class RootSystems : Feature
    {
        public RootSystems(Contexts contexts, MainGameServices services)
        {
            Add(new GameStateEventSystems(contexts));
            Add(new GameplayEventSystems(contexts));
            Add(new ServiceRegistrationSystems(contexts, services));
            Add(new InputSystems(contexts.input));
            Add(new GameplaySystems(contexts, services));
            Add(new UIEventSystems(contexts));
        }
    }
}
