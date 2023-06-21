using LamaGamma.Game;
using LamaGamma.Services;
using UnityEngine;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class LevelInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private LevelReferences _levelReferences;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<LevelInstaller>()
                .FromInstance(this)
                .AsSingle();

            BindGame();
            BindPlayer();
        }

        public void Initialize()
        {
            Container.Resolve<LevelInitializer>().Initialize();
        }

        private void BindGame()
        {
            Container.BindInstance(_levelReferences).AsSingle();
            Container.BindInterfacesAndSelfTo<ECSController>().AsSingle();
            Container.Bind<LevelInitializer>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerFactory>().AsSingle();
        }
    }
}