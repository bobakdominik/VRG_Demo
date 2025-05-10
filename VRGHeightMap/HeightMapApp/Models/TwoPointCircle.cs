using System.ComponentModel;
using System.Windows.Media;

namespace HeightMapApp.Models
{
    /// <summary>
    /// Represents a circle defined by two points: the center point and an outline point.
    /// </summary>
    class TwoPointCircle : INotifyPropertyChanged
    {
        private readonly HeightMapPoint _centerPoint;
        private readonly HeightMapPoint _outlinePoint;
        private readonly Brush _brush;
        private readonly string _name;
        private bool _isVisible;

        public string Name => _name;
        public HeightMapPoint CenterPoint => _centerPoint;
        public HeightMapPoint OutlinePoint => _outlinePoint;
        public Brush Brush => _brush;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public double RadiusForView
        {
            get
            {
                var xLength = Math.Max(CenterPoint.ViewX, OutlinePoint.ViewX) - Math.Min(CenterPoint.ViewX, OutlinePoint.ViewX);
                var yLength = Math.Max(CenterPoint.ViewY, OutlinePoint.ViewY) - Math.Min(CenterPoint.ViewY, OutlinePoint.ViewY);
                return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
            }
        }
        public double RadiusForMap
        {
            get
            {
                var xLength = Math.Max(CenterPoint.MapX, OutlinePoint.MapX) - Math.Min(CenterPoint.MapX, OutlinePoint.MapX);
                var yLength = Math.Max(CenterPoint.MapY, OutlinePoint.MapY) - Math.Min(CenterPoint.MapY, OutlinePoint.MapY);
                return Math.Sqrt(Math.Pow(xLength, 2) + Math.Pow(yLength, 2));
            }
        }

        /// <summary>
        /// Constructor for TwoPointCircle.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="centerPoint">Center point</param>
        /// <param name="outlinePoint">Outline point</param>
        /// <param name="brush">Brush</param>
        public TwoPointCircle(string name, HeightMapPoint centerPoint, HeightMapPoint outlinePoint, Brush brush)
        {
            _name = name;
            _centerPoint = centerPoint;
            _outlinePoint = outlinePoint;
            _brush = brush;
            _isVisible = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
