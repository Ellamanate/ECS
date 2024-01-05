using LamaGamma.Services.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LamaGamma.Game
{
    public class LevelReferences : SerializedMonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public HUDView HUDView { get; private set; }
    }
}
