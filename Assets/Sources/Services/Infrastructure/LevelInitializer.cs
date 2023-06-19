using LamaGamma.Infrastructure;
using LamaGamma.Services;

namespace LamaGamma.Game
{
    public class LevelInitializer
    {
        private readonly ECSController _eCSController;
        private readonly PlayerFactory _playerFactory;

        public LevelInitializer(ECSController eCSController, PlayerFactory playerFactory)
        {
            _eCSController = eCSController;
            _playerFactory = playerFactory;
        }

        public void Initialize()
        {
            _eCSController.Initialize();
            _playerFactory.Create();
        }
    }
}
