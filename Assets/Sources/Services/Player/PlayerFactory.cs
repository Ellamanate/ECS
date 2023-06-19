using UnityEngine;

namespace LamaGamma.Services
{
    public class PlayerFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly Contexts _contexts;

        public PlayerFactory(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
            _contexts = Contexts.sharedInstance;
        }

        public void Create()
        {
            var entity = CreateEntity();

            var view = Object.Instantiate(_playerConfig.Prefab);
            view.Initialize(_contexts, entity);
        }

        private GameEntity CreateEntity()
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddHealth(100);
            entity.AddPosition(Vector3.zero);
            entity.isPlayer = true;

            return entity;
        }
    }
}
