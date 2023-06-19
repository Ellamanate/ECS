using UnityEngine;

namespace LamaGamma.Views
{
    public class TransformlListener : MonoBehaviour, IViewRegistraction, IPositionListener, IRotationListener
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Register(GameEntity entity)
        {
            entity.AddPositionListener(this);
            entity.AddRotationListener(this);
        }

        public void Unregister(GameEntity entity)
        {
            entity.RemovePositionListener(this);
            entity.RemoveRotationListener(this);
        }

        public void OnPosition(GameEntity entity, Vector3 value)
        {
            //_rigidbody.position = value;
        }

        public void OnRotation(GameEntity entity, Quaternion value)
        {
            //_rigidbody.rotation = value;
        }
    }
}