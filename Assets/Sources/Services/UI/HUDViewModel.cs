namespace LamaGamma.Services.UI
{
    public class HUDViewModel
    {
        private readonly UIEntity _uIEntity;

        public HUDViewModel(UIEntity uIEntity)
        {
            _uIEntity = uIEntity;
        }

        public void SetVindow(WindowType window)
        {
            if (window == WindowType.HUD)
            {
                _uIEntity.ReplaceFade(1);
            }
            else if (_uIEntity.fade.Value == 1)
            {
                _uIEntity.ReplaceFade(0);
            }
        }
    }
}
