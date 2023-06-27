using UnityEngine;

namespace LamaGamma.Views
{
    public class RotationListener : MonoBehaviour, IViewRegistraction, IRotationListener
    {
        [SerializeField] private Transform _transform;

        public void Register(GameplayEntity entity)
        {
            entity.AddRotationListener(this);
        }

        public void Unregister(GameplayEntity entity)
        {
            entity.RemoveRotationListener(this);
        }

        public void OnRotation(GameplayEntity entity, Quaternion value)
        {
            _transform.rotation = value;
        }
    }
}