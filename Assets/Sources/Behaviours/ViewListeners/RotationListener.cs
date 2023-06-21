using UnityEngine;

namespace LamaGamma.Views
{
    public class RotationListener : MonoBehaviour, IViewRegistraction, IRotationListener
    {
        [SerializeField] private Transform _transform;

        public void Register(GameEntity entity)
        {
            entity.AddRotationListener(this);
        }

        public void Unregister(GameEntity entity)
        {
            entity.RemoveRotationListener(this);
        }

        public void OnRotation(GameEntity entity, Quaternion value)
        {
            _transform.rotation = value;
        }
    }
}