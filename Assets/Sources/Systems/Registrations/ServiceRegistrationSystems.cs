using LamaGamma.Infrastructure;
using LamaGamma.Services;

namespace LamaGamma.Systems
{
    public class ServiceRegistrationSystems : Feature
    {
        public ServiceRegistrationSystems(Contexts contexts, MainGameServices services)
          : base(nameof(ServiceRegistrationSystems))
        {
            GameContext game = contexts.game;
            InputContext input = contexts.input;

            Add(new RegisterServiceSystem<IInputService>(services.InputService, input.ReplaceInput));
        }
    }
}
