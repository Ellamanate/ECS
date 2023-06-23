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

            Add(new PlayerRotationSystem(contexts));
            Add(new PlayerMoveSystem(contexts));
            Add(new RaycastSystem(contexts, services));
            Add(new LogHealthSystem(contexts));
        }
    }
}
