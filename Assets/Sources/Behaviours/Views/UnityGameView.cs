using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

namespace LamaGamma.Views
{
    public class UnityGameView : MonoBehaviour
    {
        public Contexts Contexts;
        public GameEntity LinkedEntity;

        public void Initialize(Contexts contexts, GameEntity entity)
        {
            Contexts = contexts;
            LinkedEntity = entity;
            gameObject.Link(entity);

            RegisterViews(entity);
            Oninitialized();
        }

        public virtual void DestroyView()
        {
            UnregisterViews(LinkedEntity);
            gameObject.DestroyGameObject();
        }

        protected virtual void Oninitialized() { }

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
