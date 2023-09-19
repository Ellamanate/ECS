using UnityEngine;

namespace LamaGamma.Game
{
    public class CharacterLocomotion : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [Tooltip("The radius of the grounded check. Should match the radius of the Collider")]
        [SerializeField] private float _groundedRadius = 0.28f;

        [Tooltip("Useful for rough ground")]
        [SerializeField] private float _groundedOffset = -0.14f;

        [Tooltip("What layers the character uses as ground")]
        [SerializeField] private LayerMask _groundLayers;

        public bool Grounded { get; private set; }

        private void Update()
        {
            CheckGrounded();
        }

        private void CheckGrounded()
        {
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - _groundedOffset,
                transform.position.z);
            Grounded = Physics.CheckSphere(spherePosition, _groundedRadius, _groundLayers,
                QueryTriggerInteraction.Ignore);

            //_animator.SetBool(_animIDGrounded, Grounded);
        }
    }
}
