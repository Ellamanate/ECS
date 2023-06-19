using Entitas;
using LamaGamma.Services;

namespace LamaGamma.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly InputContext _context;
        private readonly IGroup<InputEntity> _keyboard;

        private IInputService Input => _context.input.Value;

        public EmitInputSystem(InputContext contexts)
        {
            _context = contexts;
            _keyboard = _context.GetGroup(InputMatcher.Keyboard);
        }

        public void Execute()
        {
            foreach (var keyboard in _keyboard)
            {
                keyboard.ReplaceMovement(Input.Movement);
                keyboard.ReplaceLookAt(Input.LookAt);
            }
        }
    }
}
