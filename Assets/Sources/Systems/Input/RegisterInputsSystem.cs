using Entitas;

namespace LamaGamma.Systems
{
    public class RegisterInputsSystem : IInitializeSystem
    {
        private readonly InputContext _input;

        public RegisterInputsSystem(InputContext input) => _input = input;

        public void Initialize()
        {
            _input.isInput = true;
        }
    }
}
