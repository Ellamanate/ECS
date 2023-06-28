using LamaGamma.Game;
using LamaGamma.Services;
using LamaGamma.Services.UI;
using System;
using UnityEngine;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class LevelInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private LevelReferences _levelReferences;
        [SerializeField] private int _frameRate = 60;

        public override void InstallBindings()
        {
            var contexts = Container.Resolve<Contexts>();
            BindGameState(contexts);
            BindGame();
            BindPlayer();
            BindUI(contexts);
            BindSelf();
        }

        public void Initialize()
        {
            Application.targetFrameRate = _frameRate;
            Container.Resolve<LevelInitializer>().Initialize();
        }

        private void BindSelf()
        {
            Container.BindInterfacesTo<LevelInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameState(Contexts contexts)
        {
            var stateEntity = contexts.gameState.CreateEntity();
            stateEntity.isState = true;
            stateEntity.ReplaceCanInteract(false);
            Container.Bind<GameStateEntity>().FromInstance(stateEntity);
        }

        private void BindGame()
        {
            Container.BindInstance(_levelReferences).AsSingle();
            Container.BindInterfacesAndSelfTo<ECSManager>().AsSingle();
            Container.Bind<LevelInitializer>().AsSingle();
            Container.Bind<PhysicsService>().AsSingle().WithArguments(_levelReferences.Camera);
            Container.Bind<ECSViewsRegistrator>().AsSingle();
            Container.Bind<GameEntityFactory>().AsSingle();
            Container.Bind<GameEntitysRegistrator>().AsSingle();
            Container.Bind<GameIdentifierService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ViewsLinker>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerFactory>().AsSingle();
        }

        private void BindUI(Contexts contexts)
        {
            BindViewModel<HUDViewModel, HUDBinder>(contexts, _levelReferences.HUDView);
        }

        private void BindViewModel<TViewModel, TBinder>(Contexts contexts, IView view)
        {
            var entity = contexts.uI.CreateEntity();

            Container.BindInterfacesAndSelfTo<TViewModel>().AsSingle().WithArguments(entity);
            Container
                .Bind(typeof(TBinder), typeof(IDisposable), typeof(IInitializable))
                .To<TBinder>()
                .AsSingle()
                .WithArguments(view, entity)
                .NonLazy();
        }
    }
}