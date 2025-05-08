using HeightMapApp.Models;
using HeightMapApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HeightMapApp.ViewModels
{
    class MapViewerViewModel : ViewModelBase
    {
        private readonly CircleRepository _circleRepository;

        private const string cDefaultCursorLocationText = "X: {0}, Y: {1}, Z: {2}";
        private string _cursorLocationText = string.Empty;
        private ViewableHeightMap? _ViewableHeightMap;

        public IEnumerable<CircleImageItemViewModel> CircleViewModels => _circleRepository.CircleImageViewModels;

        public ViewableHeightMap? ViewableHeightMap
        {
            get
            {
                return _ViewableHeightMap;
            }
            private set
            {
                _ViewableHeightMap = value;
                OnPropertyChanged(nameof(ViewableHeightMap));
                OnPropertyChanged(nameof(HeightMapImage));
            }
        }

        public BitmapImage? HeightMapImage => ViewableHeightMap?.HeightMapImage;

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

        public MapViewerViewModel(CircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
            ResetCursorPosition();
            ViewableHeightMap = null;
        }

        public void SetHeightMap(ViewableHeightMap heightMap)
        {
            ViewableHeightMap = heightMap;
        }

        internal void ResetCursorPosition()
        {
            CursorLocationText = string.Format(cDefaultCursorLocationText, "?", "?", "?");
        }

        internal void UpdateCursorPosition(double relativeCursorY, double relativeCursorX)
        {
            var normalizedX = (int)(relativeCursorX * ViewableHeightMap.HeightMap.Columns);
            var normalizedY = (int)(relativeCursorY * ViewableHeightMap.HeightMap.Rows);

            var invertedNormalizedY = (int)((1 - relativeCursorY) * ViewableHeightMap.HeightMap.Rows); //[0,0] index is bottom left corner

            var currentX = (normalizedX * ViewableHeightMap.HeightMap.CellSize) + ViewableHeightMap.HeightMap.StartX;
            var currentY = (invertedNormalizedY * ViewableHeightMap.HeightMap.CellSize) + ViewableHeightMap.HeightMap.StartY;
            var currentHeight = ViewableHeightMap.HeightMap[normalizedX, normalizedY];

            CursorLocationText = string.Format(cDefaultCursorLocationText, currentX, currentY, currentHeight);
        }
    }
}
