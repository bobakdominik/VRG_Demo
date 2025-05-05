using HeightMapApp.Models;
using System.Windows.Media.Imaging;

namespace HeightMapApp.ViewModels
{
    class MapViewerViewModel : ViewModelBase
    {
        private const string cDefaultCursorLocationText = "X: {0}, Y: {1}, Z: {2}";
        private string _cursorLocationText = string.Empty;
        private ViewableHeightMap _heightMap;

        public ViewableHeightMap HeightMap
        {
            get
            {
                return _heightMap;
            }
            private set
            {
                _heightMap = value;
                OnPropertyChanged(nameof(HeightMap));
                OnPropertyChanged(nameof(HeightMapImage));
            }
        }

        public BitmapImage HeightMapImage => HeightMap.HeightMapImage;


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

        public MapViewerViewModel(ViewableHeightMap heightMap)
        {
            ResetCursorPosition();
            SetHeightMap(heightMap);
        }

        public void SetHeightMap(ViewableHeightMap heightMap)
        {
            HeightMap = heightMap;
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
