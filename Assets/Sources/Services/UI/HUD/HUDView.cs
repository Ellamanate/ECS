using LamaGamma.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace LamaGamma.Services.UI
{
    public class HUDView : MonoBehaviour, IView
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Graphic _interactButton;

        public void Initialize(UIEntity entity) { }

        public void SetWindowFade(float value) => _canvasGroup.alpha = value;
        public void SetInteractionFade(float value) => _interactButton.SetAlpha(value);
    }
}
