using LamaGamma.Game;
using LamaGamma.Services;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class LevelInstaller : MonoInstaller, IInitializable
    {
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
            Container.BindInterfacesAndSelfTo<ECSController>().AsSingle();
            Container.Bind<LevelInitializer>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerFactory>().AsSingle();
        }
    }
}