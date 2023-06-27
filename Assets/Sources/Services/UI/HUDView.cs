using UnityEngine;

namespace LamaGamma.Services.UI
{
    public class HUDView : MonoBehaviour, IView
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Initialize(UIEntity entity) { }

        public void SetFade(float value) => _canvasGroup.alpha = value;
    }
}
