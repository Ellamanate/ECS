using LamaGamma.Views;
using UnityEngine;

namespace LamaGamma.Services
{
    public class PlayerFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly CameraConfig _cameraConfig;
        private readonly Contexts _contexts;

        public PlayerFactory(PlayerConfig playerConfig, CameraConfig cameraConfig, Contexts contexts)
        {
            _playerConfig = playerConfig;
            _cameraConfig = cameraConfig;
            _contexts = contexts;
        }

        public void Create()
        {
            var entity = CreateEntity();
            var view = Object.Instantiate(_playerConfig.ViewPrefab);
            view.Initialize(_contexts, entity);
            AddComponents(entity, view);
        }

        private GameEntity CreateEntity()
        {
            var entity = _contexts.game.CreateEntity();
            entity.isPlayer = true;

            return entity;
        }

        private void AddComponents(GameEntity entity, PlayerView view)
        {
            entity.ReplaceRigidbody(view.Rigidbody);

            entity.ReplaceRotationAngle(Vector2.zero);
            entity.ReplacePosition(Vector2.zero);
            entity.ReplaceRotationAngle(Vector2.zero);
            entity.ReplaceMoveSpeed(_playerConfig.Speed);
            entity.ReplaceRotationSpeed(_cameraConfig.CameraSpeed);
            entity.ReplaceSmoothingRotation(new SmoothVector3 { SmoothFactor = _cameraConfig.CameraSmoothingFactor });
            entity.ReplaceBorders(_cameraConfig.Borders);
        }
    }
}
