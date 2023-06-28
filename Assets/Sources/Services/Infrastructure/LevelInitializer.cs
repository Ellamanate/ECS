using LamaGamma.Infrastructure;
using LamaGamma.Services;

namespace LamaGamma.Game
{
    public class LevelInitializer
    {
        private readonly ECSManager _eCSManager;
        private readonly PlayerFactory _playerFactory;
        private readonly GameStateEntity _gameState;

        public LevelInitializer(ECSManager eCSManager, PlayerFactory playerFactory, GameStateEntity gameState)
        {
            _eCSManager = eCSManager;
            _playerFactory = playerFactory;
            _gameState = gameState;
        }

        public void Initialize()
        {
            _eCSManager.Initialize();
            _playerFactory.Create();
            _gameState.ReplaceWindow(WindowType.HUD);
        }
    }
}
