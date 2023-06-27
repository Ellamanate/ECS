namespace LamaGamma.Systems
{
    public class InputSystems : Feature
    {
        public InputSystems(InputContext contexts) 
            : base(nameof(InputSystems))
        {
            Add(new RegisterInputsSystem(contexts));
            Add(new EmitInputSystem(contexts));
        }
    }
}
