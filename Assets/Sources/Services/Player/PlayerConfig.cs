using LamaGamma.Views;
using UnityEngine;

namespace LamaGamma.Services
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public PlayerView ViewPrefab { get; private set; }
        [field: SerializeField] public RaycastSettings RaycastSettings { get; private set; }
        [field: SerializeField] public float Speed { get; private set; } = 1;
    }
}
