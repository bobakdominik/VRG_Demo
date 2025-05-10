using System.ComponentModel;

namespace HeightMapApp.Models
{
    /// <summary>
    /// Represents a point in a height map with associated map and view coordinates.
    /// </summary>
    internal class HeightMapPoint : INotifyPropertyChanged
    {
        private double _mapX;
        private double _mapY;
        private double _viewX;
        private double _viewY;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public double MapX
        {
            get
            {
                return _mapX;
            }
            set
            {
                _mapX = value;
                OnPropertyChanged(nameof(MapX));
            }
        }
        public double MapY
        {
            get
            {
                return _mapY;
            }
            set
            {
                _mapY = value;
                OnPropertyChanged(nameof(MapY));
            }
        }
        public double ViewX
        {
            get
            {
                return _viewX;
            }
            set
            {
                _viewX = value;
                OnPropertyChanged(nameof(ViewX));
            }   
        }
        
        public double ViewY
        {
            get
            {
                return _viewY;
            }
            set
            {
                _viewY = value;
                OnPropertyChanged(nameof(ViewY));
            }
        }

        /// <summary>
        /// Constructor for HeightMapPoint.
        /// </summary>
        /// <param name="mapY">Y position on map</param>
        /// <param name="mapX">X position on map</param>
        /// <param name="viewY">Y position on view</param>
        /// <param name="viewX">X position on view</param>
        public HeightMapPoint(double mapY, double mapX, double viewY, double viewX)
        {
            _mapX = mapX;
            _mapY = mapY;
            _viewX = viewX;
            _viewY = viewY;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
