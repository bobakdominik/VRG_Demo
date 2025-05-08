using System.ComponentModel;
using System.Windows.Media;

namespace HeightMapApp.Models
{
    class TwoPointCircle : INotifyPropertyChanged
    {
        private readonly HeightMapPoint _centerPoint;
        private readonly HeightMapPoint _outlinePoint;
        private readonly Brush _brush;
        private readonly string _name;
        private bool _visible;

        public string Name => _name;
        public HeightMapPoint CenterPoint => _centerPoint;
        public HeightMapPoint OutlinePoint => _outlinePoint;
        public Brush Brush => _brush;
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                OnPropertyChanged(nameof(Visible));
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
        
        public TwoPointCircle(string name, HeightMapPoint centerPoint, HeightMapPoint outlinePoint, Brush brush)
        {
            _name = name;
            _centerPoint = centerPoint;
            _outlinePoint = outlinePoint;
            _brush = brush;
            _visible = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
