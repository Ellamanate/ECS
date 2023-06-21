using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

namespace LamaGamma.Views
{
    public class UnityGameView : MonoBehaviour
    {
        public Contexts Contexts { get; private set; }
        public GameEntity LinkedEntity { get; private set; }

        public void Initialize(Contexts contexts, GameEntity entity)
        {
            Contexts = contexts;
            LinkedEntity = entity;
            gameObject.Link(entity);

            RegisterViews(entity);
        }

        public virtual void DestroyView()
        {
            UnregisterViews(LinkedEntity);
            gameObject.DestroyGameObject();
        }

        private void RegisterViews(GameEntity entity)
        {
            foreach (var listener in GetComponents<IViewRegistraction>())
                listener.Register(entity);
        }

        private void UnregisterViews(GameEntity entity)
        {
            foreach (var listener in GetComponents<IViewRegistraction>())
                listener.Unregister(entity);
        }
    }
}
