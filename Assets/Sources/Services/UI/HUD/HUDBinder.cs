using System;
using Zenject;

namespace LamaGamma.Services.UI
{
    public class HUDBinder : IDisposable, IInitializable, IWindowListener, ICanInteractListener, IWindowFadeListener, IInteractButtonFadeListener
    {
        private readonly HUDViewModel _viewModel;
        private readonly HUDView _view;
        private readonly GameStateEntity _gameStateEntity;
        private readonly UIEntity _uIEntity;

        public HUDBinder(HUDViewModel viewModel, HUDView view, GameStateEntity gameStateEntity, UIEntity uIEntity)
        {
            _viewModel = viewModel;
            _view = view;
            _gameStateEntity = gameStateEntity;
            _uIEntity = uIEntity;

            _gameStateEntity.AddWindowListener(this);
            _gameStateEntity.AddCanInteractListener(this);
            _uIEntity.AddWindowFadeListener(this);
            _uIEntity.AddInteractButtonFadeListener(this);
        }

        public void Initialize()
        {
            _uIEntity.ReplaceWindowFade(0);
            _uIEntity.ReplaceInteractButtonFade(0);
        }

        public void Dispose()
        {
            _gameStateEntity.RemoveWindowListener(this);
            _gameStateEntity.AddCanInteractListener(this);
            _uIEntity.RemoveWindowFadeListener(this);
            _uIEntity.RemoveInteractButtonFadeListener(this);
        }

        public void OnWindow(GameStateEntity entity, WindowType value) => _viewModel.SetVindow(value);
        public void OnCanInteract(GameStateEntity entity, bool value) => _viewModel.SetInteract(value);

        public void OnWindowFade(UIEntity entity, float value) => _view.SetWindowFade(value);
        public void OnInteractButtonFade(UIEntity entity, float value) => _view.SetInteractionFade(value);
    }
}
