using UnityEngine;

namespace LamaGamma
{
    public class StartupScene : MonoBehaviour
    {
        private RootSystems _system;

        private void Start()
        {
            var contexts = Contexts.sharedInstance;
            _system = new RootSystems(contexts);
            _system.Initialize();
        }

        private void Update()
        {
            _system.Execute();
        }
    }
}
