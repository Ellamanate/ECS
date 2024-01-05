using LamaGamma.Services;
using LamaGamma.Systems;
using System;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class ECSManager : ITickable, IDisposable
    {
        private readonly Contexts _contexts;
        private readonly RootSystems _system;

        public ECSManager(Contexts contexts, InputService inputService, PhysicsService physicsService,
            ECSViewsRegistrator viewsRegistrator, GameEntitysRegistrator entitysRegistrator)
        {
            _contexts = contexts;

            var services = new MainGameServices
            {
                InputService = inputService,
                PhysicsService = physicsService,
                ViewsRegistrator = viewsRegistrator,
                EntitysRegistrator = entitysRegistrator,
            };

            _system = new RootSystems(_contexts, services);
        }

        public void Dispose()
        {
            _system.DeactivateReactiveSystems();
            _system.Cleanup();
        }

        public void Initialize()
        {
            _system.Initialize();
        }

        public void Tick()
        {
            _system.Execute();
        }
    }
}
