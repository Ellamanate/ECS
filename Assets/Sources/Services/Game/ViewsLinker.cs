using LamaGamma.Views;
using Zenject;

namespace LamaGamma.Services
{
    public class ViewsLinker : IInitializable
    {
        private readonly Contexts _contexts;
        private readonly ViewsRegistrator _registrator;
        private readonly GameEntityFactory _entityFactory;
        private readonly IView[] _views;

        public ViewsLinker(Contexts contexts, ViewsRegistrator registrator, GameEntityFactory entityFactory, IView[] views)
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
                var entity = CreateEntity(view);
                entity.isInteractable = true;
            }
        }

        public GameEntity CreateEntity(IView view)
        {
            var entity = _entityFactory.Create();
            view.Initialize(_contexts, entity);

            _registrator.Register(view.InstanceId, view);

            return entity;
        }
    }
}
