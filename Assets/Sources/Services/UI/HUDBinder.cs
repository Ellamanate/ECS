using System;

namespace LamaGamma.Services.UI
{
    public class HUDBinder : IDisposable, IWindowListener, IFadeListener
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
            _uIEntity.AddFadeListener(this);
        }

        public void Dispose()
        {
            _gameStateEntity.RemoveWindowListener(this);
            _uIEntity.RemoveFadeListener(this);
        }

        public void OnWindow(GameStateEntity entity, WindowType value) => _viewModel.SetVindow(value);

        public void OnFade(UIEntity entity, float value) => _view.SetFade(value);
    }
}
