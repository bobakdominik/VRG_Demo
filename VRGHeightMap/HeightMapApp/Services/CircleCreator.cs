using HeightMapApp.Models;
using System.ComponentModel;
using System.Windows.Media;

namespace HeightMapApp.Services
{
    internal class CircleCreator : INotifyPropertyChanged, IDisposable
    {
        private readonly CircleRepository _circleRepository;
        private HeightMapCursorCoordinates? _cursorCoordinates;
        private TwoPointCircle? _currentCircle;

        private bool _creatingCircle;
        private bool _isFirstPointSet;
        private int _createdCirclesCount;


        public TwoPointCircle? Circle
        {
            get { return _currentCircle; }
            private set
            {
                if (_currentCircle != value)
                {
                    _currentCircle = value;
                    OnPropertyChanged(nameof(Circle));
                }
            }
        }

        public HeightMapCursorCoordinates? CursorCoordinates
        {
            get { return _cursorCoordinates; }
            set
            {
                if (_cursorCoordinates != null)
                {
                    _cursorCoordinates.PropertyChanged -= CursorCoordinates_PropertyChanged;
                }
                if (_cursorCoordinates != value)
                {
                    _cursorCoordinates = value;
                    OnPropertyChanged(nameof(CursorCoordinates));
                }
                if (_cursorCoordinates != null)
                {
                    _cursorCoordinates.PropertyChanged += CursorCoordinates_PropertyChanged;
                }
            }
        }

        public bool IsCreatingCircle
        {
            get { return _creatingCircle; }
            private set
            {
                if (_creatingCircle != value)
                {
                    _creatingCircle = value;
                    OnPropertyChanged(nameof(IsCreatingCircle));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public CircleCreator(CircleRepository circleRepository) 
        {
            _circleRepository = circleRepository;
            _createdCirclesCount = _circleRepository.Circles.Count();
            ResetCircleCreation();
        }

        public void ResetCircleCreation()
        {
            IsCreatingCircle = false;
            _isFirstPointSet = false;
            Circle = null;
        }

        public void StartCircleCreation()
        {
            if (!IsCreatingCircle && CursorCoordinates != null)
            {
                IsCreatingCircle = true;
                var name = string.Format($"C{_createdCirclesCount + 1}");
                var centerPoint = new HeightMapPoint(CursorCoordinates.MapY, CursorCoordinates.MapX, CursorCoordinates.ViewY, CursorCoordinates.ViewX);
                var outlinePoint = new HeightMapPoint(CursorCoordinates.MapY, CursorCoordinates.MapX, CursorCoordinates.ViewY, CursorCoordinates.ViewX);
                var brush = CreateRandomBrush();
                Circle = new TwoPointCircle(name, centerPoint, outlinePoint, brush);
            }
        }

        public void SaveCurrentLocation()
        {
            if (IsCreatingCircle)
            {
                Circle.OutlinePoint.MapX = CursorCoordinates.MapX;
                Circle.OutlinePoint.MapY = CursorCoordinates.MapY;
                Circle.OutlinePoint.ViewX = CursorCoordinates.ViewX;
                Circle.OutlinePoint.ViewY = CursorCoordinates.ViewY;
                if (!_isFirstPointSet)
                {
                    Circle.CenterPoint.MapX = CursorCoordinates.MapX;
                    Circle.CenterPoint.MapY = CursorCoordinates.MapY;
                    Circle.CenterPoint.ViewX = CursorCoordinates.ViewX;
                    Circle.CenterPoint.ViewY = CursorCoordinates.ViewY;
                    _isFirstPointSet = true;
                }
                else
                {
                    _circleRepository.AddCircle(Circle);
                    _createdCirclesCount++;
                    ResetCircleCreation();
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SolidColorBrush CreateRandomBrush()
        {
            var random = new Random();
            var color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            return new SolidColorBrush(color);
        }

        private void CursorCoordinates_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (IsCreatingCircle)
            {
                if (_isFirstPointSet)
                {
                    Circle.OutlinePoint.MapX = CursorCoordinates.MapX;
                    Circle.OutlinePoint.MapY = CursorCoordinates.MapY;
                    Circle.OutlinePoint.ViewX = CursorCoordinates.ViewX;
                    Circle.OutlinePoint.ViewY = CursorCoordinates.ViewY;
                }
            }
        }

        public void Dispose()
        {
            if (CursorCoordinates != null)
            {
                CursorCoordinates.PropertyChanged -= CursorCoordinates_PropertyChanged;
            }
        }
    }
}
