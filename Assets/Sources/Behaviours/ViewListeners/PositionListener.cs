using UnityEngine;

namespace LamaGamma.Views
{
    public class PositionListener : MonoBehaviour, IViewRegistraction, IPositionListener
    {
        [SerializeField] private Transform _transform;

        public void Register(GameEntity entity)
        {
            entity.AddPositionListener(this);
        }

        public void Unregister(GameEntity entity)
        {
            entity.RemovePositionListener(this);
        }

        public void OnPosition(GameEntity entity, Vector3 value)
        {
            _transform.position = value;
        }
    }
}