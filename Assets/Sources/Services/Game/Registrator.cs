using System.Collections.Generic;

namespace LamaGamma.Services
{
    public class Registrator<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _objectsById = new Dictionary<TKey, TValue>();

        public TValue Register(TKey id, TValue value)
        {
            _objectsById[id] = value;
            return value;
        }

        public void Unregister(TKey id)
        {
            if (Contains(id))
                _objectsById.Remove(id);
        }

        public bool Contains(TKey instanceId)
        {
            return _objectsById.ContainsKey(instanceId);
        }

        public TValue Take(TKey key) =>
          _objectsById.TryGetValue(key, out TValue value)
            ? value
            : default;
    }
}
