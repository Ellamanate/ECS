using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using LamaGamma.Utils;
using System;

namespace LamaGamma.Services.UI
{
    public class HUDViewModel : IDisposable
    {
        private readonly UIEntity _uIEntity;

        private TweenerCore<float, float, FloatOptions> _windowTween;
        private TweenerCore<float, float, FloatOptions> _interactTween;

        public HUDViewModel(UIEntity uIEntity)
        {
            _uIEntity = uIEntity;
        }

        public void Dispose()
        {
            _windowTween?.Kill();
            _interactTween?.Kill();
        }

        public void SetVindow(WindowType window)
            => _windowTween.FadeAlpha(() => _uIEntity.windowFade.Value, x => _uIEntity.ReplaceWindowFade(x), 1, window == WindowType.HUD);

        public void SetInteract(bool canInteract)
            => _interactTween.FadeAlpha(() => _uIEntity.interactButtonFade.Value, x => _uIEntity.ReplaceInteractButtonFade(x), 1, canInteract);
    }
}
