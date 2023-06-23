namespace LamaGamma.Services
{
    public class GameEntityFactory
    {
        private readonly Contexts _contexts;
        private readonly GameIdentifierService _identifier;
        private readonly GameEntitysRegistrator _entitysRegistrator;

        public GameEntityFactory(Contexts contexts, GameIdentifierService identifier, GameEntitysRegistrator entitysRegistrator)
        {
            _contexts = contexts;
            _identifier = identifier;
            _entitysRegistrator = entitysRegistrator;
        }

        public GameEntity Create()
        {
            int id = _identifier.Next(Identity.General);
            var entity = _contexts.game.CreateEntity();
            entity.ReplaceId(id);

            _entitysRegistrator.Register(id, entity);

            return entity;
        }
    }
}
