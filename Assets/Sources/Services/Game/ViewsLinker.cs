using LamaGamma.Views;
using Zenject;

namespace LamaGamma.Services
{
    public class ViewsLinker : IInitializable
    {
        private readonly Contexts _contexts;
        private readonly ViewsRegistrator _registrator;
        private readonly GameIdentifierService _identifier;
        private readonly IView[] _views;

        public ViewsLinker(Contexts contexts, ViewsRegistrator registrator, GameIdentifierService identifier, IView[] views)
        {
            _contexts = contexts;
            _registrator = registrator;
            _identifier = identifier;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                CreateEntity(view);
            }
        }

        public GameEntity CreateEntity(IView view)
        {
            var entity = _contexts.game.CreateEntity();
            entity.ReplaceId(_identifier.Next(Identity.General));

            view.Initialize(_contexts, entity);

            _registrator.Register(view.InstanceId, view);

            return entity;
        }
    }
}
