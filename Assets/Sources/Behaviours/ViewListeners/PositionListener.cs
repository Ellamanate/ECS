using UnityEngine;

namespace LamaGamma.Views
{
    public class PositionListener : MonoBehaviour, IViewRegistraction, IPositionListener
    {
        [SerializeField] private Transform _transform;

        public void Register(GameplayEntity entity)
        {
            entity.AddPositionListener(this);
        }

        public void Unregister(GameplayEntity entity)
        {
            entity.RemovePositionListener(this);
        }

        public void OnPosition(GameplayEntity entity, Vector3 value)
        {
            _transform.position = value;
        }
    }
}