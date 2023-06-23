using Entitas;
using LamaGamma.Services;

namespace LamaGamma.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly InputContext _context;
        private readonly IGroup<InputEntity> _input;

        private InputService Input => _context.inputService.Value;

        public EmitInputSystem(InputContext contexts)
        {
            _context = contexts;
            _input = _context.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (var input in _input)
            {
                input.ReplaceMovement(Input.Movement);
                input.ReplaceLookAt(Input.LookAt);
                input.isInteractDown = Input.Interact;
            }
        }
    }
}
