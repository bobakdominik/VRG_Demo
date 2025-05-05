namespace HeightMapApp.ViewModels
{
    class MapViewerViewModel : ViewModelBase
    {
        private const string cDefaultCursorLocationText = "X: {0}, Y: {1}, Z: {2}";
        private string _cursorLocationText = string.Empty;

        public string CursorLocationText
        {
            get
            {
                return _cursorLocationText;
            }
            private set
            {
                _cursorLocationText = value;
                OnPropertyChanged(nameof(CursorLocationText));
            }
        }

        public MapViewerViewModel()
        {
            ResetCursorPosition();
        }


        internal void ResetCursorPosition()
        {
            CursorLocationText = string.Format(cDefaultCursorLocationText, "?", "?", "?");
        }

        internal void UpdateCursorPosition(int y, int x)
        {
            CursorLocationText = string.Format(cDefaultCursorLocationText, x, y, "?");
        }
    }
}
