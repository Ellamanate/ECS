using LamaGamma.Views;
using Zenject;

namespace LamaGamma.Services
{
    public class ViewsLinker : IInitializable
    {
        private readonly Contexts _contexts;
        private readonly ECSViewsRegistrator _registrator;
        private readonly GameEntityFactory _entityFactory;
        private readonly IGameplayView[] _views;

        public ViewsLinker(Contexts contexts, ECSViewsRegistrator registrator,
            GameEntityFactory entityFactory, IGameplayView[] views)
        {
            _contexts = contexts;
            _registrator = registrator;
            _entityFactory = entityFactory;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                var entity = _entityFactory.Create();
                entity.isInteractable = true;

                LinkEntity(view, entity);
            }
        }

        public void LinkEntity(IGameplayView view, GameplayEntity entity)
        {
            view.Initialize(_contexts, entity);
            _registrator.Register(view.InstanceId, view);
        }
    }
}
