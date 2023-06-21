using LamaGamma.Infrastructure;
using LamaGamma.Services;
using UnityEngine;

namespace LamaGamma.Game
{
    public class LevelInitializer
    {
        private readonly ECSController _eCSController;
        private readonly PlayerFactory _playerFactory;
        private readonly LevelReferences _references;
        private readonly Contexts _contexts;

        public LevelInitializer(ECSController eCSController, PlayerFactory playerFactory, LevelReferences references, Contexts contexts)
        {
            _eCSController = eCSController;
            _playerFactory = playerFactory;
            _references = references;
            _contexts = contexts;
        }

        public void Initialize()
        {
            _eCSController.Initialize();
            _playerFactory.Create();
            Application.targetFrameRate = 60;
        }
    }
}
