using LamaGamma.Services;
using UnityEngine;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private ScenesConfig _scenesConfig;

        public override void InstallBindings()
        {
            BindEntitasContexts();
            BindConfigs();
            BindInput();
            BindGameStates();

            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindEntitasContexts()
        {
            Container.BindInstance(new Contexts()).AsSingle().NonLazy();
        }

        private void BindConfigs()
        {
            Container.BindInstance(_playerConfig).AsSingle();
            Container.BindInstance(_cameraConfig).AsSingle();
            Container.BindInstance(_scenesConfig).AsSingle();
        }        
        
        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            Container.BindFactory<GameStateMachine, BootstrapState, BootstrapState.Factory>().AsSingle();
            Container.BindFactory<GameStateMachine, GameLoopState, GameLoopState.Factory>().AsSingle();
            Container.BindFactory<GameStateMachine, LoadingState, LoadingState.Factory>().AsSingle();
        }

        public void Initialize()
        {
            var boostrapState = Container.Resolve<GameStateMachine>();
            boostrapState.MoveToState<BootstrapState>();
        }
    }
}