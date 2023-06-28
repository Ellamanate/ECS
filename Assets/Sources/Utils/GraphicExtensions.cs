using UnityEngine.UI;

namespace LamaGamma.Utils
{
    public static class GraphicExtensions
    {
        public static Image SetAlpha(this Image image, float alpha)
        {
            var color = image.color;
            color.a = alpha;
            image.color = color;

            return image;
        }
    }
}
