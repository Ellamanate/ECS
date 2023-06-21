using LamaGamma.Services;
using UnityEngine;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;

        public override void InstallBindings()
        {
            BindEntitasContexts();
            BindConfigs();
            BindInput();
        }

        private void BindEntitasContexts()
        {
            Container.BindInstance(new Contexts()).AsSingle().NonLazy();
        }

        private void BindConfigs()
        {
            Container.BindInstance(_playerConfig).AsSingle();
            Container.BindInstance(_cameraConfig).AsSingle();
        }        
        
        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
    }
}