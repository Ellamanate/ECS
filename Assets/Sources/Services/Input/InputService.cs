using UnityEngine;

namespace LamaGamma.Services
{
    public class InputService : IInputService
    {
        public InputService()
        {

        }

        public Vector2 Movement => Input.GetKey(KeyCode.W) ? Vector2.one : Vector2.zero;
        public Vector2 LookAt => Input.GetKey(KeyCode.S) ? Vector2.one : Vector2.zero;
    }
}
