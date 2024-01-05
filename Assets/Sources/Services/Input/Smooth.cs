namespace LamaGamma.Services
{
    [System.Serializable]
    public struct Smooth<T>
    {
        public T SmoothValue;
        public float SmoothFactor;
    }
}
