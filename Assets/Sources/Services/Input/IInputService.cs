using UnityEngine;

namespace LamaGamma.Services
{
    public interface IInputService
    {
        public Vector2 Movement { get; }
        public Vector2 LookAt { get; }
    }
}
