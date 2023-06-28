using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace LamaGamma.Utils
{
    public static class AnimationExtensions
    {
        public static TweenerCore<float, float, FloatOptions> FadeAlpha(this TweenerCore<float, float, FloatOptions> tween, 
            DOGetter<float> get, DOSetter<float> set, float duration, bool FadeIn)
        {
            if (FadeIn)
                Fade(ref tween, get, set, 1, duration);
            else
                Fade(ref tween, get, set, 0, duration);

            return tween;
        }

        public static void Fade(ref TweenerCore<float, float, FloatOptions> tween, DOGetter<float> get, DOSetter<float> set, 
            float endValue, float duration)
        {
            if (get.Invoke() != endValue && (tween == null || tween.active == false || tween.endValue != endValue))
            {
                tween?.Kill();
                tween = DOTween.To(get, set, endValue, duration);
            }
        }
    }
}
