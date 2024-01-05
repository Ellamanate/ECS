using Tymski;
using UnityEngine;

namespace LamaGamma.Infrastructure
{
    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Configs/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        [field: SerializeField] public SceneReference StartScene { get; private set; }
    }
}
