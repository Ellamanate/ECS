using UnityEngine;

namespace LamaGamma.Views
{
    public class PlayerView : UnityGameView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}
