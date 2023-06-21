using UnityEngine;

namespace LamaGamma.Services
{
    public class PlayerFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly Contexts _contexts;

        public PlayerFactory(PlayerConfig playerConfig, Contexts contexts)
        {
            _playerConfig = playerConfig;
            _contexts = contexts;
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
            entity.isPlayer = true;
            entity.AddRotationAngle(Vector2.zero);

            return entity;
        }
    }
}
