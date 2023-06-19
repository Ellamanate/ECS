using UnityEngine;

namespace LamaGamma.Views
{
    public class RigidbodyRegister : MonoBehaviour, IViewRegistraction
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Register(GameEntity entity)
        {
            entity.AddRigidbody(_rigidbody);
        }

        public void Unregister(GameEntity entity)
        {
            entity.RemoveRigidbody();
        }
    }
}