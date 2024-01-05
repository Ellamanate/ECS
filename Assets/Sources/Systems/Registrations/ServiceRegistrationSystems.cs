using LamaGamma.Infrastructure;
using LamaGamma.Services;

namespace LamaGamma.Systems
{
    public class ServiceRegistrationSystems : Feature
    {
        public ServiceRegistrationSystems(Contexts contexts, MainGameServices services)
          : base(nameof(ServiceRegistrationSystems))
        {
            GameplayContext game = contexts.gameplay;
            InputContext input = contexts.input;

            Add(new RegisterServiceSystem<InputService>(services.InputService, input.ReplaceInputService));
        }
    }
}
