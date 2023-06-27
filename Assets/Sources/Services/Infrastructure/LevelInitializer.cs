using LamaGamma.Infrastructure;
using LamaGamma.Services;

namespace LamaGamma.Game
{
    public class LevelInitializer
    {
        private readonly ECSManager _eCSManager;
        private readonly PlayerFactory _playerFactory;

        public LevelInitializer(ECSManager eCSManager, PlayerFactory playerFactory)
        {
            _eCSManager = eCSManager;
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            _eCSManager.Initialize();

            var player = _playerFactory.Create();
            var entity = player.LinkedEntity;
        }
    }
}
