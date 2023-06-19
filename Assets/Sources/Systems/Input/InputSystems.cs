namespace LamaGamma.Systems
{
    public class InputSystems : Feature
    {
        public InputSystems(InputContext contexts) 
            : base(nameof(InputSystems))
        {
            Add(new EmitInputSystem(contexts));
            Add(new RegisterInputsSystem(contexts));
        }
    }
}
