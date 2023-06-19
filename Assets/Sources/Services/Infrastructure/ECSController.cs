using LamaGamma.Services;
using LamaGamma.Systems;
using System;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class ECSController : ITickable, IDisposable
    {
        private readonly Contexts _contexts;
        private readonly RootSystems _system;

        public ECSController(InputService inputService)
        {
            _contexts = Contexts.sharedInstance;

            var services = new MainGameServices
            {
                InputService = inputService
            };

            _system = new RootSystems(_contexts, services);
        }

        public void Dispose()
        {
            //_system.DeactivateReactiveSystems();
            //_contexts.Reset();
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
