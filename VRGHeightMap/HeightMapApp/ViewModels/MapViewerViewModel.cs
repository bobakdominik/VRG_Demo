using HeightMapApp.Models;
using HeightMapApp.Services;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HeightMapApp.ViewModels
{
    /// <summary>
    /// ViewModel for the map viewer, responsible for managing the height map and circle creation.
    /// </summary>
    class MapViewerViewModel : ViewModelBase
    {
        private readonly CircleRepository _circleRepository;
        private readonly CircleCreator _circleCreator;
        private readonly HeightMapCursorCoordinates _cursoCoordinates;
        private const string cDefaultCursorLocationText = "X: {0}   Y: {1}   Z: {2}";
        private string _cursorLocationText = string.Empty;
        private ViewableHeightMap? _ViewableHeightMap;
        private CircleImageItemViewModel? _createdCircle;

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

        public Cursor OnMapCursor => _circleCreator.IsCreatingCircle ? Cursors.Cross : Cursors.Arrow;

        public CircleImageItemViewModel? CreatedCircle
        {
            get
            {
                return _createdCircle;
            }
            private set
            {
                _createdCircle = value;
                OnPropertyChanged(nameof(CreatedCircle));
            }
        }

        /// <summary>
        /// Constructor for the MapViewerViewModel.
        /// </summary>
        /// <param name="circleRepository">Circle repository</param>
        /// <param name="circleCreator">Circle Creator</param>
        public MapViewerViewModel(CircleRepository circleRepository, CircleCreator circleCreator)
        {
            _circleRepository = circleRepository;
            _circleCreator = circleCreator;
            _cursoCoordinates = new HeightMapCursorCoordinates();
            _circleCreator.CursorCoordinates = _cursoCoordinates;
            ViewableHeightMap = null;

            _circleCreator.PropertyChanged += SelectedCircle_PropertyChanged;
            ResetCursorPosition();
        }

        /// <summary>
        /// Sets the height map for the view model.
        /// </summary>
        /// <param name="heightMap"></param>
        public void SetHeightMap(ViewableHeightMap heightMap)
        {
            _circleRepository.Clear();
            ViewableHeightMap = heightMap;
        }

        /// <summary>
        /// Resets the cursor position to default values.
        /// </summary>
        internal void ResetCursorPosition()
        {
            _cursoCoordinates.ResetCoordinates();
            UpdateCursorLocationText();
        }

        /// <summary>
        /// Updates the cursor position based on the relative cursor coordinates and view dimensions.
        /// </summary>
        /// <param name="relativeCursorY">Relative X cursor position on view in range 0-1</param>
        /// <param name="relativeCursorX">Relative Y cursor position on view in range 0-1</param>
        /// <param name="viewHeight">Height of view</param>
        /// <param name="viewWidth">Width of view</param>
        internal void UpdateCursorPosition(double relativeCursorY, double relativeCursorX, double viewHeight, double viewWidth)
        {
            var normalizedX = (int)(relativeCursorX * ViewableHeightMap.HeightMap.Columns);
            var normalizedY = (int)(relativeCursorY * ViewableHeightMap.HeightMap.Rows);
            var invertedNormalizedY = (int)((1 - relativeCursorY) * ViewableHeightMap.HeightMap.Rows); //[0,0] index is bottom left corner

            var currentX = (normalizedX * ViewableHeightMap.HeightMap.CellSize) + ViewableHeightMap.HeightMap.StartX;
            var currentY = (invertedNormalizedY * ViewableHeightMap.HeightMap.CellSize) + ViewableHeightMap.HeightMap.StartY;
            var currentHeight = ViewableHeightMap.HeightMap[normalizedX, normalizedY];

            _cursoCoordinates.MapX = currentX;
            _cursoCoordinates.MapY = currentY;
            _cursoCoordinates.ViewX = (relativeCursorX * viewWidth);
            _cursoCoordinates.ViewY = (relativeCursorY * viewHeight);
            _cursoCoordinates.OnMapHeight = currentHeight;
            UpdateCursorLocationText();
        }

        /// <summary>
        /// Saves the current cursor position for circle creation.
        /// </summary>
        internal void SaveCursorPosition()
        {
            _circleCreator.SaveCurrentLocation();
        }

        /// <summary>
        /// Cancels circle creation.
        /// </summary>
        internal void CancelCircleCreation()
        {
            _circleCreator.ResetCircleCreation();
        }

        private void UpdateCursorLocationText()
        {
            if (_cursoCoordinates.MapX < 0 || _cursoCoordinates.MapY < 0)
            {
                CursorLocationText = string.Format(cDefaultCursorLocationText, "?", "?", "?");
            }
            else
            {
                CursorLocationText = string.Format(cDefaultCursorLocationText, 
                    _cursoCoordinates.MapX.ToString("0.##"),
                    _cursoCoordinates.MapY.ToString("0.##"), 
                    _cursoCoordinates.OnMapHeight.ToString("0.##"));
            }
        }

        private void SelectedCircle_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_circleCreator.IsCreatingCircle))
            {
                OnPropertyChanged(nameof(OnMapCursor));
                if (_circleCreator.IsCreatingCircle && ViewableHeightMap == null)
                {
                    _circleCreator.ResetCircleCreation();
                }
            }
            else if (e.PropertyName == nameof(_circleCreator.Circle))
            {
                if (_circleCreator.Circle != null)
                {
                    CreatedCircle = new CircleImageItemViewModel(_circleCreator.Circle);
                }
                else
                {
                    CreatedCircle = null;
                }
            }
        }

        protected override void Dispose()
        {
            _circleCreator.PropertyChanged -= SelectedCircle_PropertyChanged;
            base.Dispose();
        }
    }
}
