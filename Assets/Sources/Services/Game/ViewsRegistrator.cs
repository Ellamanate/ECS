using LamaGamma.Views;
using System.Collections.Generic;

namespace LamaGamma.Services
{
    public class ViewsRegistrator
    {
        private readonly Dictionary<int, IView> _viewByInstanceId = new Dictionary<int, IView>();

        public IView Register(int instanceId, IView viewController)
        {
            _viewByInstanceId[instanceId] = viewController;
            return viewController;
        }

        public void Unregister(int instanceId)
        {
            if (Contains(instanceId))
                _viewByInstanceId.Remove(instanceId);
        }

        public bool Contains(int instanceId)
        {
            return _viewByInstanceId.ContainsKey(instanceId);
        }

        public IView Take(int key) =>
          _viewByInstanceId.TryGetValue(key, out IView view)
            ? view
            : null;
    }
}
