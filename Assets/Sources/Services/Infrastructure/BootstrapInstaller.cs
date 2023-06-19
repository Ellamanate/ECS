using LamaGamma.Services;
using UnityEngine;
using Zenject;

namespace LamaGamma.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            BindConfigs();
            BindInput();
        }

        private void BindConfigs()
        {
            Container.BindInstance(_playerConfig).AsSingle();
        }        
        
        private void BindInput()
        {
            Container.Bind<InputService>().AsSingle();
        }
    }
}