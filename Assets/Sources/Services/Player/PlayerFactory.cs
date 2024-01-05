using LamaGamma.Views;
using UnityEngine;

namespace LamaGamma.Services
{
    public class PlayerFactory
    {
        private readonly PlayerConfig _playerConfig;
        private readonly CameraConfig _cameraConfig;
        private readonly GameEntityFactory _entityFactory;
        private readonly ViewsLinker _linker;

        public PlayerFactory(PlayerConfig playerConfig, CameraConfig cameraConfig,
            GameEntityFactory entityFactory, ViewsLinker linker)
        {
            _playerConfig = playerConfig;
            _cameraConfig = cameraConfig;
            _entityFactory = entityFactory;
            _linker = linker;
        }

        public PlayerView Create()
        {
            var view = Object.Instantiate(_playerConfig.ViewPrefab);
            var entity = _entityFactory.Create();

            _linker.LinkEntity(view, entity);

            AddComponents(entity, view);

            return view;
        }

        private void AddComponents(GameplayEntity entity, PlayerView view)
        {
            entity.isPlayer = true;
            entity.ReplaceRigidbody(view.Rigidbody);

            entity.ReplaceRotationAngle(Vector2.zero);
            entity.ReplacePosition(Vector2.zero);
            entity.ReplaceRotationAngle(Vector2.zero);
            entity.ReplaceMoveSpeed(_playerConfig.Speed);
            entity.ReplaceRotationSpeed(_cameraConfig.CameraSpeed);
            entity.ReplaceSmoothingRotation(new Smooth<Vector2> { SmoothFactor = _cameraConfig.CameraSmoothingFactor });
            entity.ReplaceBorders(_cameraConfig.Borders);
            entity.ReplaceRaycasting(_playerConfig.RaycastSettings);
            entity.ReplaceInSightId(-1);
        }
    }
}
