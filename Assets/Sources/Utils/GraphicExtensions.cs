using UnityEngine.UI;

namespace LamaGamma.Utils
{
    public static class GraphicExtensions
    {
        public static Graphic SetAlpha(this Graphic image, float alpha)
        {
            var color = image.color;
            color.a = alpha;
            image.color = color;

            return image;
        }
    }
}
